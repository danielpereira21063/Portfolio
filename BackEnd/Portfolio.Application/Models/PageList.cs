namespace Portfolio.Application.Models
{
    public class PageList<T>
    {
        public int PaginaAtual { get; set; }
        public int TotalPaginas { get; set; }
        public int ItensPorPagina { get; set; }
        public int QtdTotal { get; set; }
        public ICollection<T> Itens { get; set; } = new List<T>();

        public PageList() { }

        public PageList(ICollection<T> itens, int qtd, int numeroPagina, int itensPorPagina)
        {
            QtdTotal = qtd;
            ItensPorPagina = itensPorPagina;
            PaginaAtual = numeroPagina;
            TotalPaginas = (int)Math.Ceiling(qtd / (double)itensPorPagina);

            itens.ToList().ForEach(item => Itens.Add(item));
        }

        public static PageList<T> Create(
            ICollection<T> source, int pageNumber, int pageSize
        )
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToList();
            return new PageList<T>(items, count, pageNumber, pageSize);
        }
    }
}
