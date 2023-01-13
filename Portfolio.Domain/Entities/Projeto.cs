namespace Portfolio.Domain.Entities
{
    public class Projeto : AbstractEntity
    {
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public string Url { get; private set; }
        public string UrlGitHub { get; private set; }
        public bool Inativo { get; private set; }
        public int PortfolioId { get; private set; }
        public InformacoesPortfolio Portfolio { get; private set; }
        public ICollection<ImagemProjeto> ImagemProjeto { get; private set; }

        public Projeto()
        {

        }

        public Projeto(string titulo, string descricao, string url, string urlGitHub, int portfolioId)
        {
            Titulo = titulo;
            Descricao = descricao;
            Url = url;
            UrlGitHub = urlGitHub;
            PortfolioId = portfolioId;
        }

        public void AlterarTitulo(string titulo) => Titulo = titulo;
        public void AlterarDescricao(string descricao) => Descricao = descricao;
        public void AlterarUrl(string url) => Url = url;
        public void AlterarUrlGithub(string urlGithub) => UrlGitHub = urlGithub;
        public void Inativar() => Inativo = true;
        public void Ativar() => Inativo = false;
    }
}
