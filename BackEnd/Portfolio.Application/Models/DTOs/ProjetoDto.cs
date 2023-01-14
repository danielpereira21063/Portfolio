using Portfolio.Application.DTOs.AbstractModels;

namespace Portfolio.Application.Models.DTOs
{
    public class ProjetoDto : AsbtractDto
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Url { get; set; }
        public string UrlGitHub { get; set; }
        public bool Inativo { get; set; }
        public int PortfolioId { get; set; }
        public ICollection<ImagemProjetoDto> ImagensProjeto { get; set; }
    }
}
