namespace Portfolio.Application.Models.DTOs
{
    public class HabilidadeDto
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get;  set; }
        public byte[] Imagem { get; set; }
        public int DadosPortfolioId { get; set; }
    }
}
