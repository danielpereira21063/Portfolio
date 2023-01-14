using Portfolio.Domain.Entities;

namespace Portfolio.Domain.Test.Builders
{
    public class ImagemProjetoBuilder
    {
        public byte[] _imagem = new byte[] { 0x00, 0x01, 0x02, 0x03 };
        public bool _principal = false;
        public int _projetoId = 1;


        public static ImagemProjetoBuilder Novo()
        {
            return new ImagemProjetoBuilder();
        }

        public ImagemProjetoBuilder ComImagem(byte[] imagem)
        {
            _imagem = imagem;
            return this;
        }

        public ImagemProjetoBuilder ComProjetoId(int projetoId)
        {
            _projetoId = projetoId;
            return this;
        }

        public ImagemProjetoBuilder Principal()
        {
            _principal = true;
            return this;
        }

        public ImagemProjeto Build()
        {
            return new ImagemProjeto(_imagem, _principal, _projetoId);
        }
    }
}
