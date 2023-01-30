import { AxiosResponse } from "axios";
import User from "../models/User";
import UserLogin from "../models/UserLogin";
import api from "./api";

const baseUrl = "/account";

const login = async (data: UserLogin) => {
    try {
        const response: AxiosResponse = await api.post(`${baseUrl}/login`, data);

        const user: User = response.data;

        if (user) {
            salvarUsuarioLocalStorage(user);
            AddAuthorizationHeader(user.token);
            // setAuthenticated(true);

            return user;
        }

        // setLoading(false);
    } catch (error: any) {
        // setLoginError(error.response.data);
        // setLoading(false);
    }
}

const logout = async () => {
    localStorage.removeItem("usuario");
    RemoveAuthorizationHeader();
    // setAuthenticated(false);

    location.href = "/admin/login";
}

function salvarUsuarioLocalStorage(usuario: User): void {
    localStorage.setItem("usuario", JSON.stringify(usuario));
}

function obterUsuarioLocalStorage(): User | null {
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

export const AccountService = {
    login,
    logout,
    salvarUsuarioLocalStorage,
    obterUsuarioLocalStorage,
    AddAuthorizationHeader,
    RemoveAuthorizationHeader
}