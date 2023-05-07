using Portfolio.Application.DTOs.AbstractModels;

namespace Portfolio.Application.Models.DTOs
{
    public class HabilidadeDto : AsbtractDto
    {
        public int DadosPortfolioId { get; set; }
        public string ImagemBase64 { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
