namespace Portfolio.Domain.Entities
{
    public class Projeto : AbstractEntity
    {
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public string Url { get; private set; }
        public string LinkGitHub { get; private set; }
        public int PortfolioId { get; private set; }
        public Portfolio Portfolio { get; private set; }
        public ICollection<ImagemProjeto> ImagemProjeto { get; private set; }
    }
}
