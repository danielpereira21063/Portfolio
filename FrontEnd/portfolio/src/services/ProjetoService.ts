import api from "./api/index";
import Projeto from "../models/Projeto";
import PageList from "../models/PageList";

const baseUrl = "/projeto";

const obterTodos = async (portfolioId: number, obterInativos = false, search = "", numeroPagina = 1): Promise<PageList<Projeto> | void> => {
    try {
        let queryParams = `obterInativos=${obterInativos}&numeroPagina=${numeroPagina}`;
        search != "" ? queryParams += `&termoBusca=${search}` : "";
        const { data } = await api.get(`/projeto/portfolio/${portfolioId}?${queryParams}`);
        return data;
    } catch (error: any) {
        // TOAS aqui
    }
}

const obterPeloId = async (id: number): Promise<Projeto | void> => {
    try {
        const { data } = await api.get(`${baseUrl}/${id}`);
        return data;
    } catch (error: any) {
        // TOAS aqui
    }
}

const salvar = async (projeto: Projeto) => {
    try {
        const { data } = await api.post(baseUrl, projeto);
        return data;
    } catch (error: any) {
        // throw new ApiException(error?.message);

    }
}

const alterarStatus = async (id: number): Promise<Projeto | void> => {
    try {
        const { data } = await api.put(`${baseUrl}/alterarStatus/${id}`);
        return data;
    } catch (error: any) {
        console.log(error)
        // TOAST aqui
    }
}


export const ProjetoService = {
    obterTodos,
    salvar,
    obterPeloId,
    alterarStatus
}