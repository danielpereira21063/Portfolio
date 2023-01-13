namespace Portfolio.Domain.Entities
{
    public class Portfolio : AbstractEntity
    {
        public string NomeCompleto { get; private set; }
        public string Linkedin { get; private set; }
        public string Facebook { get; private set; }
        public string Instagram { get; private set; }
        public string Youtube { get; private set; }
        public string WhatsApp { get; private set; }
        public string Email { get; private set; }
        public ICollection<Projeto> Projetos { get; private set; }
    }
}
