using Bogus;
using ExpectedObjects;
using Portfolio.Domain.Entities;
using Portfolio.Domain.Test.Builders;
using Portfolio.Domain.Test.Util;
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
        private readonly int _dadosPortfolioId;

        private readonly Faker _faker;

        public ProjetoTest()
        {
            _faker = new Faker("pt_BR");

            _titulo = _faker.Commerce.ProductName();
            _descricao = _faker.Commerce.ProductDescription();
            _url = _faker.Internet.Url();
            _urlGitHub = _faker.Internet.UrlWithPath();
            _inativo = false;
            _dadosPortfolioId = _faker.Random.Int(1, int.MaxValue);
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
                DadosPortfolioId = _dadosPortfolioId
            };

            var projeto = new Projeto(projetoEsperado.Titulo, projetoEsperado.Descricao, projetoEsperado.Url, projetoEsperado.UrlGitHub, projetoEsperado.DadosPortfolioId);

            projetoEsperado.ToExpectedObject().ShouldMatch(projeto);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void NaoDeveCriarComTituloInvalido(string tituloInvalido)
        {
            Assert.Throws<DomainException>(()
                => ProjetoBuilder.Novo().ComTitulo(tituloInvalido).Build()).ComMensagem(ProjetoMsgErros.TITULO_INVALIDO);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void NaoDeveCriarComDescricaoInvalida(string descricaoInvalida)
        {
            Assert.Throws<DomainException>(()
                => ProjetoBuilder.Novo().ComDescricao(descricaoInvalida).Build()).ComMensagem(ProjetoMsgErros.DESCRICAO_INVALIDA);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("urlInvalida")]
        [InlineData(" ")]
        public void NaoDeveCriarComUrlInvalida(string urlInvalida)
        {
            Assert.Throws<DomainException>(()
                => ProjetoBuilder.Novo().ComUrl(urlInvalida).Build()).ComMensagem(ProjetoMsgErros.URL_INVALIDA);
        }


        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("urlGitHubInvalida")]
        [InlineData(" ")]
        public void NaoDeveCriarComUrlGitHubInvalida(string urlGitHubInvalida)
        {
            Assert.Throws<DomainException>(()
                => ProjetoBuilder.Novo().ComUrlGitHub(urlGitHubInvalida).Build()).ComMensagem(ProjetoMsgErros.URL_GITHUB_INVALIDA);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void NaoDeveCriarComPortfolioIdInvalido(int portfolioIdInvalido)
        {
            Assert.Throws<DomainException>(() =>
                ProjetoBuilder.Novo().ComPortfolioId(portfolioIdInvalido).Build()).ComMensagem(ProjetoMsgErros.PORTFOLIO_ID_INVALIDO);
        }


        [Fact]
        public void DeveAlterarTitulo()
        {
            var tituloEsperado = _faker.Commerce.ProductName();
            var projeto = ProjetoBuilder.Novo().Build();

            projeto.AlterarTitulo(tituloEsperado);
            Assert.Equal(tituloEsperado, projeto.Titulo);
        }

        [Fact]
        public void DeveAlterarDescricao()
        {
            var descricaoEsperada = _faker.Commerce.ProductDescription();
            var projeto = ProjetoBuilder.Novo().Build();

            projeto.AlterarDescricao(descricaoEsperada);
            Assert.Equal(descricaoEsperada, projeto.Descricao);
        }

        [Fact]
        public void DeveAlterarUrl()
        {
            var urlEsperada = _faker.Internet.Url();
            var projeto = ProjetoBuilder.Novo().Build();

            projeto.AlterarUrl(urlEsperada);
            Assert.Equal(urlEsperada, projeto.Url);
        }

        [Fact]
        public void DeveAlterarUrlGitHub()
        {
            var urlGitHubEsperada = _faker.Internet.Url();
            var projeto = ProjetoBuilder.Novo().Build();

            projeto.AlterarUrlGitHub(urlGitHubEsperada);
            Assert.Equal(urlGitHubEsperada, projeto.UrlGitHub);
        }
    }
}
