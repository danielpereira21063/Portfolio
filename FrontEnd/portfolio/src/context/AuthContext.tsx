import { AxiosResponse } from "axios";
import React, { createContext, useState, useEffect } from "react";
import api from "../services/api";
import User from "../models/User";
import UserLogin from "../models/UserLogin";
import { useNavigate } from "react-router-dom";

const AuthContext = createContext<any>({});

function AuthProvider({ children }: any) {
    const [authenticated, setAuthenticated] = useState(false);
    const [loading, setLoading] = useState(true);
    const [loginError, setLoginError] = useState(null);

    useEffect(() => {
        const user = obterUsuario();

        if (user) {
            AddAuthorizationHeader(user.token);
            setAuthenticated(true);
        }

        setLoading(false);
    }, []);

    async function login(data: UserLogin) {
        try {
            setLoading(true);
            setLoginError(null);

            const response: AxiosResponse = await api.post("/account/login", data);

            const user: User = response.data;

            if (user) {
                salvarUsuario(user);
                AddAuthorizationHeader(user.token);
                setAuthenticated(true);

                return user;
            }

            setLoading(false);
        } catch (error: any) {
            setLoginError(error.response.data);
            setLoading(false);
        }
    }

    function logout(): void {
        localStorage.removeItem("usuario");
        RemoveAuthorizationHeader();
        setAuthenticated(false);
    }

    function salvarUsuario(usuario: User): void {
        localStorage.setItem("usuario", JSON.stringify(usuario));
    }

    function obterUsuario(): User | null {
        const usuario = localStorage.getItem("usuario") || null;

        if (!usuario) return null;

        return JSON.parse(usuario);
    }

    function AddAuthorizationHeader(token: string): void {
        api.defaults.headers.Authorization = `Bearer ${token}`;
    }

    function RemoveAuthorizationHeader(): void {
        api.defaults.headers.Authorization = null;
    }

    return (
        <AuthContext.Provider value={{ authenticated, loading, login, logout, loginError }}>
            {children}
        </AuthContext.Provider>
    );
}

export { AuthContext, AuthProvider };