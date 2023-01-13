namespace Portfolio.Domain.Entities
{
    public class InformacoesPortfolio : AbstractEntity
    {
        public string NomeCompleto { get; private set; }
        public string Linkedin { get; private set; }
        public string Facebook { get; private set; }
        public string Instagram { get; private set; }
        public string Youtube { get; private set; }
        public string WhatsApp { get; private set; }
        public string Email { get; private set; }
        public ICollection<Projeto> Projetos { get; private set; }

        public InformacoesPortfolio()
        {

        }

        public InformacoesPortfolio(string nomeCompleto, string linkedin, string facebook, string instagram, string youtube, string whatsApp, string email)
        {
            NomeCompleto = nomeCompleto;
            Linkedin = linkedin;
            Facebook = facebook;
            Instagram = instagram;
            Youtube = youtube;
            WhatsApp = whatsApp;
            Email = email;
        }

        public void AlterarNomeComleto(string nomeCompleto) => NomeCompleto = nomeCompleto;
        public void AlterarLinkedin(string linkedin) => Linkedin = linkedin;
        public void AlterarFacebook(string facebook) => Facebook = facebook;
        public void AlterarInstagram(string instagram) => Instagram = instagram;
        public void AlterarYoutube(string youtube) => Youtube = youtube;
        public void AlterarWhatsapp(string whatsApp) => WhatsApp = whatsApp;
        public void AlterarEmail(string email) => Email = email;
    }
}
