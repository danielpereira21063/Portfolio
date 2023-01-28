import axios from "axios";

const env = process.env.NODE_ENV || 'development';

let API_URL = "https://portfolio-api.danielsanchesdev.com.br/api";

if (env == "development") {
    API_URL = "https://portfolio-api.dev.danielsanchesdev.com.br/api";
}

export default axios.create({
    baseURL: API_URL
});