using Bogus;
using ExpectedObjects;
using Portfolio.Domain.Entities;
using Xunit;

namespace Portfolio.Domain.Test.Entities
{
    public class DadosPortfolioTest
    {
        private readonly string _nomeCompleto;
        private readonly string _mensagemApresentacao;
        private readonly byte[] _imagemPerfil;
        private readonly string _linkedinURL;
        private readonly string _facebookURL;
        private readonly string _twitterURL;
        private readonly string _instagramURL;
        private readonly string _youtubeURL;
        private readonly string _whatsApp;
        private readonly string _email;
        private readonly int _userId;

        private readonly Faker _faker;

        public DadosPortfolioTest()
        {
            _faker = new Faker("pt_BR");

            _nomeCompleto = _faker.Person.FullName;
            _mensagemApresentacao = _faker.Lorem.Paragraph();
            _linkedinURL = _faker.Internet.UrlWithPath();
            _imagemPerfil = _faker.Image.Random.Bytes(16);
            _facebookURL = _faker.Internet.UrlWithPath();
            _twitterURL = _faker.Internet.UrlWithPath();
            _instagramURL = _faker.Internet.UrlWithPath();
            _youtubeURL = _faker.Internet.UrlWithPath();
            _whatsApp = _faker.Person.Phone.Replace("-", "").Replace("+55 ", "");
            _email = _faker.Person.Email;
            _userId = _faker.Random.Int(1, int.MaxValue);

            //var qtdProjetos = _faker.Random.Int(1, 5);
            //for (int i = 0; i < qtdProjetos; i++)
            //{
            //    var projeto = ProjetoBuilder.Novo().Build();
            //    _projetos.Add(projeto);
            //}
        }

        [Fact]
        public void DeveCriarDadosPortfolio()
        {
            var dadosPortfolioEsperado = new
            {
                NomeCompleto = _nomeCompleto,
                MensagenApresentacao = _mensagemApresentacao,
                ImagemPerfil = _imagemPerfil,
                LinkedinURL = _linkedinURL,
                FacebookURL = _facebookURL,
                TwitterURL = _twitterURL,
                InstagramURL = _instagramURL,
                YoutubeURL = _youtubeURL,
                WhatsApp = _whatsApp,
                Email = _email,
                UserId = _userId,
            };

            var dadosPortfolio = new DadosPortfolio(dadosPortfolioEsperado.NomeCompleto,
                                                    dadosPortfolioEsperado.MensagenApresentacao,
                                                    dadosPortfolioEsperado.ImagemPerfil,
                                                    dadosPortfolioEsperado.LinkedinURL,
                                                    dadosPortfolioEsperado.FacebookURL,
                                                    dadosPortfolioEsperado.TwitterURL,
                                                    dadosPortfolioEsperado.InstagramURL,
                                                    dadosPortfolioEsperado.YoutubeURL,
                                                    dadosPortfolioEsperado.WhatsApp,
                                                    dadosPortfolioEsperado.Email,
                                                    dadosPortfolioEsperado.UserId);

            dadosPortfolioEsperado.ToExpectedObject().ShouldMatch(dadosPortfolio);
        }
    }
}
