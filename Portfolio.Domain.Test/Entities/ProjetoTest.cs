using Bogus;
using ExpectedObjects;
using Portfolio.Domain.Entities;
using Portfolio.Domain.Test.Builders;
using Portfolio.Domain.Validacoes.Exceptions;
using Portfolio.Domain.Validacoes.MensagemDeErros;
using Xunit;

namespace Portfolio.Domain.Test.Entities
{
    public class ProjetoTest
    {
        private readonly string _titulo;
        private readonly string _descricao;
        private readonly string _url;
        private readonly string _urlGitHub;
        private readonly bool _inativo;
        private readonly int _portfolioId;


        private readonly Faker _faker;

        public ProjetoTest()
        {
            _faker = new Faker("pt_BR");

            _titulo = _faker.Commerce.ProductName();
            _descricao = _faker.Commerce.ProductDescription();
            _url = _faker.Internet.Url();
            _urlGitHub = _faker.Internet.Url();
            _inativo = false;
            _portfolioId = _faker.Random.Int(1, int.MaxValue);
        }


        [Fact]
        public void DeveCriarProjeto()
        {
            var projetoEsperado = new
            {
                Titulo = _titulo,
                Descricao = _descricao,
                Url = _url,
                UrlGitHub = _urlGitHub,
                Inativo = _inativo,
                PortfolioId = _portfolioId
            };

            var projeto = new Projeto(projetoEsperado.Titulo, projetoEsperado.Descricao, projetoEsperado.Url, projetoEsperado.UrlGitHub, projetoEsperado.PortfolioId);

            projetoEsperado.ToExpectedObject().ShouldMatch(projeto);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void NaoDeveProjetoTerTituloInvalido(string tituloInvalido)
        {
            Assert.Throws<DomainException>(()
                => ProjetoBuilder.Novo().ComTitulo(tituloInvalido)).ComMensagem(ProjetoMsgErros.TITULO_INVALIDO);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void NaoDeveProjetoTerDescricaoInvalida(string descricaoInvalida)
        {
            Assert.Throws<DomainException>(()
                => ProjetoBuilder.Novo().ComDescricao(descricaoInvalida)).ComMensagem(ProjetoMsgErros.DESCRICAO_INVALIDA);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("urlInvalida")]
        [InlineData(" ")]
        public void NaoDeveProjetoTerUrlInvalida(string urlInvalida)
        {
            Assert.Throws<DomainException>(()
                => ProjetoBuilder.Novo().ComUrl(urlInvalida)).ComMensagem(ProjetoMsgErros.URL_INVALIDA);
        }


        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("urlGitHubInvalida")]
        [InlineData(" ")]
        public void NaoDeveProjetoTerUrlGitHubInvalida(string urlGitHubInvalida)
        {
            Assert.Throws<DomainException>(()
                => ProjetoBuilder.Novo().ComUrlGitHub(urlGitHubInvalida)).ComMensagem(ProjetoMsgErros.URL_INVALIDA);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void NaoDeveProjetoTerPortfolioIdInvalido(int portfolioIdInvalido)
        {
            Assert.Throws<DomainException>(()
                => ProjetoBuilder.Novo().ComPortfolioId(portfolioIdInvalido)).ComMensagem(ProjetoMsgErros.PORTFOLIO_ID_INVALIDO);
        }
    }
}
