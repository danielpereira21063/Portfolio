using ExpectedObjects;
using Portfolio.Domain.Entities;
using Xunit;

namespace Portfolio.Domain.Test.Entities
{
    public class ImagemProjetoTest
    {
        private readonly byte[] _imagem;
        private readonly bool _principal;
        private readonly int _projetoId;

        [Fact]
        public void DeveCriarImagemProjeto()
        {
            var imagemProjetoEsperada = new
            {
                Imagem = _imagem,
                Principal = _principal,
                ProjetoId = _projetoId
            };

            var imagemProjeto = new ImagemProjeto(_imagem, _principal, _projetoId);

            imagemProjetoEsperada.ToExpectedObject().ShouldMatch(imagemProjeto);
        }
    }
}
