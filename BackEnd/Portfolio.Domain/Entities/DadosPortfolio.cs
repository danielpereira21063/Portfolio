using Portfolio.Domain.Identity;
using Portfolio.Domain.Validacoes;
using Portfolio.Domain.Validacoes.MensagemDeErros;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Domain.Entities
{
    public class DadosPortfolio : AbstractEntity
    {
        [Column(TypeName = "VARCHAR(250)")]
        public string NomeCompleto { get; private set; }

        public string MensagemApresentacao { get; private set; }


        [Column(TypeName = "MEDIUMBLOB")]
        public byte[]? ImagemPerfil { get; private set; }


        [Column(TypeName = "VARCHAR(250)")]
        public string LinkedinURL { get; private set; }


        [Column(TypeName = "VARCHAR(250)")]
        public string FacebookUrl { get; private set; }


        [Column(TypeName = "VARCHAR(250)")]
        public string TwitterURL { get; private set; }


        [Column(TypeName = "VARCHAR(250)")]
        public string InstagramURL { get; private set; }


        [Column(TypeName = "VARCHAR(250)")]
        public string YoutubeURL { get; private set; }


        [Column(TypeName = "VARCHAR(250)")]
        public string WhatsApp { get; set; }


        [Column(TypeName = "VARCHAR(100)")]
        public string Email { get; private set; }

        public User User { get; private set; }
        public int UserId { get; private set; }
        public ICollection<Projeto> Projetos { get; private set; }
        public ICollection<Habilidade> Habilidades { get; private set; }

        public DadosPortfolio()
        {

        }

        public DadosPortfolio(string nomeCompleto, string mensagemApresentacao, byte[]? imagemPerfil, string linkedinUrl, string facebookUrl, string twitterURL, string instagramUrl, string youtubeUrl, string whatsApp, string email, int userId)
        {
            NomeCompleto = nomeCompleto;
            MensagemApresentacao = mensagemApresentacao;
            ImagemPerfil = imagemPerfil;
            LinkedinURL = linkedinUrl;
            FacebookUrl = facebookUrl;
            TwitterURL = twitterURL;
            InstagramURL = instagramUrl;
            YoutubeURL = youtubeUrl;
            WhatsApp = whatsApp;
            Email = email;
            UserId = userId;

            Validar();
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
                .Quando(!ValidadorDeExpressao.ValidarUrl(LinkedinURL), DadosPortfolioMsgErros.URL_LINKEDIN_INVALIDA)
                .Quando(!ValidadorDeExpressao.ValidarUrl(FacebookUrl), DadosPortfolioMsgErros.URL_FACEBOOK_INVALIDA)
                .Quando(!ValidadorDeExpressao.ValidarUrl(TwitterURL), DadosPortfolioMsgErros.URL_TWITTER_INVALIDA)
                .Quando(!ValidadorDeExpressao.ValidarUrl(InstagramURL), DadosPortfolioMsgErros.URL_INSTAGRAM_INVALIDA)
                .Quando(!ValidadorDeExpressao.ValidarUrl(YoutubeURL), DadosPortfolioMsgErros.URL_YOUTUBE_INVALIDA)
                .Quando(!ValidadorDeExpressao.ValidarCelular(WhatsApp), DadosPortfolioMsgErros.WHATSAPP_INVALIDO)
                .Quando(!ValidadorDeExpressao.ValidarEmail(Email), DadosPortfolioMsgErros.EMAIL_INVALIDO)
                .LancarExcecoesSeExistir();
        }
    }
}
