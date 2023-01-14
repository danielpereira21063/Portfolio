using Portfolio.Domain.Entities;

namespace Portfolio.Domain.Test.Builders
{
    public class ProjetoBuilder
    {
        private int _id;
        public string _titulo = "Minha Rede Social v2.0";
        public string _descricao = "Rede Social contruída para fins de aplicar meu conhecimento em um projeto";
        public string _url = "https://social-network.danielsanchesdev.com.br";
        public string _urlGitHub = "https://github.com/danielpereira21063/MySocialNetworkWeb";
        public bool _inativo = false;
        public int _portfolioId = 1;


        public static ProjetoBuilder Novo()
        {
            return new ProjetoBuilder();
        }

        public ProjetoBuilder ComTitulo(string titulo)
        {
            _titulo = titulo;
            return this;
        }

        public ProjetoBuilder ComDescricao(string descricao)
        {
            _descricao = descricao;
            return this;
        }

        public ProjetoBuilder ComUrl(string url)
        {
            _url = url;
            return this;
        }

        public ProjetoBuilder ComUrlGitHub(string urlGitHub)
        {
            _urlGitHub = urlGitHub;
            return this;
        }

        public ProjetoBuilder ComPortfolioId(int portfolioId)
        {
            _portfolioId = portfolioId;
            return this;
        }

        public ProjetoBuilder Inativo()
        {
            _inativo = true;
            return this;
        }

        public Projeto Build()
        {
            return new Projeto(_titulo, _descricao, _url, _urlGitHub, _portfolioId);
        }
    }
}
