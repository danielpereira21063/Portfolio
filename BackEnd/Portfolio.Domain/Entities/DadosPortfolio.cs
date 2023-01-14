using Portfolio.Domain.Identity;
using Portfolio.Domain.Validacoes;
using Portfolio.Domain.Validacoes.MensagemDeErros;
using System.Collections.Generic;

namespace Portfolio.Domain.Entities
{
    public class DadosPortfolio : AbstractEntity
    {
        public string NomeCompleto { get; private set; }
        public string MensagemApresentacao { get; private set; }
        public string LinkedinURL { get; private set; }
        public string FacebookUrl { get; private set; }
        public string TwitterURL { get; private set; }
        public string InstagramURL { get; private set; }
        public string YoutubeURL { get; private set; }
        public string WhatsApp { get; set; }
        public string Email { get; private set; }
        public User User { get; private set; }
        public int UserId { get; private set; }
        public ICollection<Projeto> Projetos { get; private set; }

        public DadosPortfolio()
        {

        }

        public DadosPortfolio(string nomeCompleto, string mensagemApresentacao, string linkedinUrl, string facebookUrl, string twitterURL, string instagramUrl, string youtubeUrl, string whatsApp, string email, int userId)
        {
            NomeCompleto = nomeCompleto;
            MensagemApresentacao = mensagemApresentacao;
            LinkedinURL = linkedinUrl;
            FacebookUrl = facebookUrl;
            InstagramURL = instagramUrl;
            YoutubeURL = youtubeUrl;
            WhatsApp = whatsApp;
            Email = email;
            UserId = userId;
            TwitterURL = twitterURL;
        }

        public void AlterarNomeComleto(string nomeCompleto) => NomeCompleto = nomeCompleto;
        public void AlterarUrlLinkedin(string linkedinUrl) => LinkedinURL = linkedinUrl;
        public void AlterarUrlFacebook(string facebookUrl) => FacebookUrl = facebookUrl;
        public void AlterarUrlTwitter(string twiterUrl) => TwitterURL = twiterUrl;
        public void AlterarUrlInstagram(string instagramUrl) => InstagramURL = instagramUrl;
        public void AlterarUrlYoutube(string youtubeUrl) => YoutubeURL = youtubeUrl;
        public void AlterarWhatsapp(string whatsApp) => WhatsApp = whatsApp;
        public void AlterarEmail(string email) => Email = email;
        public void AlterarMensagemDeApresentacao(string mensagemApresentacao) => MensagemApresentacao = mensagemApresentacao;

        protected override void Validar()
        {
            ValidadorDeEntidade.Novo()
                .Quando(string.IsNullOrEmpty(NomeCompleto), DadosPortfolioMsgErros.NOME_COMPLETO_INVALIDO)
                .Quando(!ValidadorDeExpressao.ValidarUrl(LinkedinURL) || string.IsNullOrEmpty(LinkedinURL), DadosPortfolioMsgErros.URL_LINKEDIN_INVALIDA)
                .Quando(!ValidadorDeExpressao.ValidarUrl(FacebookUrl) || string.IsNullOrEmpty(FacebookUrl), DadosPortfolioMsgErros.URL_FACEBOOK_INVALIDA)
                .Quando(!ValidadorDeExpressao.ValidarUrl(TwitterURL) || string.IsNullOrEmpty(TwitterURL), DadosPortfolioMsgErros.URL_TWITTER_INVALIDA)
                .Quando(!ValidadorDeExpressao.ValidarUrl(InstagramURL) || string.IsNullOrEmpty(InstagramURL), DadosPortfolioMsgErros.URL_INSTAGRAM_INVALIDA)
                .Quando(!ValidadorDeExpressao.ValidarUrl(YoutubeURL) || string.IsNullOrEmpty(YoutubeURL), DadosPortfolioMsgErros.URL_YOUTUBE_INVALIDA)
                .LancarExcecoesSeExistir();
        }
    }
}
