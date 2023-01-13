using Portfolio.Domain.Identity;
using System.Collections.Generic;

namespace Portfolio.Domain.Entities
{
    public class DadosPortfolio : AbstractEntity
    {
        public string NomeCompleto { get; private set; }
        public string Apresentacao { get; private set; }
        public string Linkedin { get; private set; }
        public string Facebook { get; private set; }
        public string Instagram { get; private set; }
        public string Youtube { get; private set; }
        public string WhatsApp { get; private set; }
        public string Email { get; private set; }
        public User User { get; private set; }
        public int UserId { get; private set; }
        public ICollection<Projeto> Projetos { get; private set; }

        public DadosPortfolio()
        {

        }

        public DadosPortfolio(string nomeCompleto, string apresentacao, string linkedin, string facebook, string instagram, string youtube, string whatsApp, string email, int userId)
        {
            NomeCompleto = nomeCompleto;
            Apresentacao = apresentacao;
            Linkedin = linkedin;
            Facebook = facebook;
            Instagram = instagram;
            Youtube = youtube;
            WhatsApp = whatsApp;
            Email = email;
            UserId = userId;
        }

        public void AlterarNomeComleto(string nomeCompleto) => NomeCompleto = nomeCompleto;
        public void AlterarLinkedin(string linkedin) => Linkedin = linkedin;
        public void AlterarFacebook(string facebook) => Facebook = facebook;
        public void AlterarInstagram(string instagram) => Instagram = instagram;
        public void AlterarYoutube(string youtube) => Youtube = youtube;
        public void AlterarWhatsapp(string whatsApp) => WhatsApp = whatsApp;
        public void AlterarEmail(string email) => Email = email;
        public void AlterarApresentacao(string apresentacao) => Apresentacao = apresentacao;
    }
}
