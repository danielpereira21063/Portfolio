namespace Portfolio.Domain.Entities
{
    public class ImagemProjeto : AbstractEntity
    {
        public byte[] Imagem { get; private set; }
        public bool Principal { get; private set; }
        public Projeto Projeto { get; private set; }
        public int ProjetoId { get; private set; }
    }
}
