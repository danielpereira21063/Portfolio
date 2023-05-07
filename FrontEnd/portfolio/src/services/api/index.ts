import axios from "axios";
import { json } from "stream/consumers";
import User from "../../models/User";
import { AccountService } from "../AccountService";

const env = process.env.NODE_ENV || 'development';

let API_URL = "https://portfolio-api.dev.danielsanchesdev.com.br/api";

if (env == "development") {
    API_URL = "https://127.0.0.1:7178/api";
    // API_URL = "https://portfolio-api.dev.danielsanchesdev.com.br/api";
}

const usuarioString = localStorage.getItem("usuario") ? localStorage.getItem("usuario") : null;

let token = "Bearer ";

if (usuarioString) {
    const usuario = JSON.parse(usuarioString);
    token += usuario.token;
}

export default axios.create({
    baseURL: API_URL,
    headers: {
        "Authorization": token
    }
});
