import Habilidade from "./Habilidade";

interface DadosPortfolio {
    id: number,
    nomeCompleto: string,
    mensagemApresentacao: string,
    linkedinURL: string,
    facebookURL: string,
    twitterURL: string,
    instagramURL: string,
    youtubeURL: string,
    whatsApp: string,
    email: string,
    userId: string,
    dataCadastro: string,
    Habilidade: Habilidade[]
}

export default DadosPortfolio;