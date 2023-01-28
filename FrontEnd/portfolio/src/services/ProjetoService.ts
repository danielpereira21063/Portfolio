import api from "./api/index";
import Projeto from "../models/Projeto";
import { ApiException } from "./api/ApiException";

const obterTodos = async (portfolioId: number, search = "", inativos = false): Promise<Projeto[] | ApiException> => {
    try {
        const { data } = await api.get(`/projeto/portfolio/${portfolioId}`);
        return data;
    } catch (error: any) {
        return new ApiException(error.message || "Erro ao consultar dados da api");
    }
}

const obterPeloId = async (id: number): Promise<Projeto | ApiException> => {
    try {
        const { data } = await api.get(`/projeto/${id}`);
        return data;
    } catch (error: any) {
        return new ApiException(error.message || "Erro ao consultar dados da api");
    }
}

const salvar = async (projeto: Projeto) => {
    try {
        const { data } = await api.post("/projeto", projeto);
        return data;
    } catch (error: any) {
        return new ApiException(error.message || "Erro ao atualizar dados da api");
    }
}

const inativar = async (id: number) => {
    try {
        const { data } = await api.post(`/projeto/alterarStatus/${id}`);
        return data;
    } catch (error: any) {
        return new ApiException(error.message || "Erro ao atualizar dados da api");
    }
}


export const ProjetoService = {
    obterTodos,
    salvar,
    obterPeloId,
    inativar
}