import DadosPortfolio from "../models/DadosPortfolio";
import api from "./api";

const baseUrl = "/portfolio";

const obterDadosPortfolio = async (): Promise<DadosPortfolio | void> => {
    try {
        const { data } = await api.get(baseUrl);
        return data;
    } catch (error: any) {
        console.log(error.message)
    }
}

const atualizarPortfolio = async (dadosPortfolio: DadosPortfolio): Promise<DadosPortfolio | void> => {
    try {
        const { data } = await api.put(baseUrl, dadosPortfolio);
        return data;
    } catch (error: any) {
        console.log(error.message)
    }
}

export const PortfolioService = {
    obterDadosPortfolio,
    atualizarPortfolio
}