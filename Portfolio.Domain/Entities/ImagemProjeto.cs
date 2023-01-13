namespace Portfolio.Domain.Entities
{
    public class ImagemProjeto : AbstractEntity
    {
        public byte[] Imagem { get; private set; }
        public bool Principal { get; private set; }
        public Projeto Projeto { get; private set; }
        public int ProjetoId { get; private set; }

        public ImagemProjeto()
        {

        }

        public ImagemProjeto(byte[] imagem, bool principal, int projetoId)
        {
            Imagem = imagem;
            Principal = principal;
            ProjetoId = projetoId;
        }

        public void AlterarImagem(byte[] imagem) => Imagem = imagem;
        public void DefinirComoPrincipal() => Principal = true;
        public void DefinirComoNaoPrincipal() => Principal = false;
    }
}
