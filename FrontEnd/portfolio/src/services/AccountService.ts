import User from "../models/User";
import UserLogin from "../models/UserLogin";
import api from "./api";

const baseUrl = "/account";

const login = async (userLogin: UserLogin): Promise<User | String> => {
    try {
        const { data } = await api.post(`${baseUrl}/login`, userLogin);

        salvarUsuarioLocalStorage(data);
        addAuthorizationHeader(data);
        // setAuthenticated(true);

        return data;
    } catch (error: any) {
        return error.response.data;
    }
}

const logout = async () => {
    localStorage.removeItem("usuario");
    removeAuthorizationHeader();
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

function addAuthorizationHeader(token: string): void {
    api.defaults.headers.Authorization = `Bearer ${token}`;
}

function removeAuthorizationHeader(): void {
    api.defaults.headers.Authorization = null;
}

export const AccountService = {
    login,
    logout,
    salvarUsuarioLocalStorage,
    obterUsuarioLocalStorage,
    addAuthorizationHeader,
    removeAuthorizationHeader
}