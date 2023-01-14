using Portfolio.Domain.Entities;

namespace Portfolio.Domain.Test.Builders
{
    public class DadosPortfolioBuilder
    {
        public string _nomeCompleto = "Daniel Pereira Sanches";
        public string _mensagemApresentacao = "Olá, me chamo Daniel e gosto muito do que faço. É muito legal!!!";
        public string _linkedinURL = "https://www.linkedin.com/in/daniel-pereira-sanches-0a1ba0210/";
        public string _facebookURL = "https://www.facebook.com/DanielPereira6301/";
        public string _twitterURL = "https://twitter.com/daniel21063";
        public string _instagramURL = "https://www.instagram.com/danielpereira21063/";
        public string _youtubeURL = "https://www.youtube.com/@danielpereirasanches";
        public string _whatsApp = "+5522999668032";
        public string _email = "danielsanches6301@mail.com";
        public int _userId = 1;


        public static DadosPortfolioBuilder Novo()
        {
            return new DadosPortfolioBuilder();
        }

        public DadosPortfolioBuilder ComNomeCompleto(string nomeCompleto)
        {
            _nomeCompleto = nomeCompleto;
            return this;
        }

        public DadosPortfolioBuilder ComMensagemApresentacao(string mensagemApresentacao)
        {
            _mensagemApresentacao = mensagemApresentacao;
            return this;
        }

        public DadosPortfolioBuilder ComLinkedinUrl(string linkedinUrl)
        {
            _linkedinURL = linkedinUrl;
            return this;
        }

        public DadosPortfolioBuilder ComFacebookUrl(string facebookUrl)
        {
            _facebookURL = facebookUrl;
            return this;
        }

        public DadosPortfolioBuilder ComTwitterUrl(string twitterUrl)
        {
            _twitterURL = twitterUrl;
            return this;
        }

        public DadosPortfolioBuilder ComNomeInstagramUrl(string instagramUrl)
        {
            _instagramURL = instagramUrl;
            return this;
        }

        public DadosPortfolioBuilder ComYoutubeUrl(string youtubeUrl)
        {
            _youtubeURL = youtubeUrl;
            return this;
        }

        public DadosPortfolioBuilder ComWhatsApp(string whatsapp)
        {
            _whatsApp = whatsapp;
            return this;
        }

        public DadosPortfolioBuilder ComEmail(string email)
        {
            _email = email;
            return this;
        }

        public DadosPortfolioBuilder ComUserId(int userId)
        {
            _userId = userId;
            return this;
        }


        public DadosPortfolio Build()
        {
            return new DadosPortfolio(_nomeCompleto, _mensagemApresentacao, _linkedinURL, _facebookURL, _twitterURL, _instagramURL, _youtubeURL, _whatsApp, _email, _userId);
        }
    }
}
