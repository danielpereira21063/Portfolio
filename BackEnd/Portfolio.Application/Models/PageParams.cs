using System.ComponentModel.DataAnnotations;

namespace Portfolio.Application.Models
{
    public class PageParams
    {
        public const int TamanhoMaxPagina = 10;
        public int NumeroPagina { get; set; } = 1;
        public int tamanhoPagina = 6;
        public int TamanhoPagina
        {
            get { return tamanhoPagina; }
            set { tamanhoPagina = (value > TamanhoMaxPagina) ? TamanhoMaxPagina : value; }
        }

        public string termoBusca { get; set; } = string.Empty;
    }
}
