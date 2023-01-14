using Portfolio.Application.DTOs.AbstractModels;

namespace Portfolio.Application.Models.DTOs
{
    public class DadosPortfolioDto : AsbtractDto
    {
        public string NomeCompleto { get; set; }
        public string Apresentacao { get; set; }
        public string LinkedinURL { get; set; }
        public string FacebookURL { get; set; }
        public string InstagramURL { get; set; }
        public string YoutubeURL { get; set; }
        public string WhatsApp { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }
    }
}
