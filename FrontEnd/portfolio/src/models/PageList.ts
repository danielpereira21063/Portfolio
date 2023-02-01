interface PageList<T> {
    paginaAtual: number;
    totalPaginas: number;
    itensPorPagina: number
    qtdTotal: number;
    itens: Array<T>;
}

export default PageList;