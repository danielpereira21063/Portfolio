using Bogus;
using ExpectedObjects;
using Portfolio.Domain.Entities;
using Portfolio.Domain.Test.Builders;
using Portfolio.Domain.Test.Util;
using Portfolio.Domain.Validacoes.Exceptions;
using Portfolio.Domain.Validacoes.MensagemDeErros;
using Xunit;

namespace Portfolio.Domain.Test.Entities
{
    public class ImagemProjetoTest
    {
        private readonly byte[] _imagem;
        private readonly bool _principal;
        private readonly int _projetoId;

        private readonly Faker _faker;


        public ImagemProjetoTest()
        {
            _faker = new Faker("pt_BR");

            _imagem = _faker.Image.Random.Bytes(8);
            _principal = false;
            _projetoId = _faker.Random.Int(1, int.MaxValue);
        }

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

        [Theory]
        [InlineData(null)]
        [InlineData(new byte[] { })]
        public void NaoDeveCriarComImagemInvalida(byte[] imagemInvalida)
        {
            Assert.Throws<DomainException>(() =>
                ImagemProjetoBuilder.Novo().ComImagem(imagemInvalida).Build()).ComMensagem(ImagemProjetoMsgErros.IMAGEM_INVALIDA);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void NaoDeveCriarComProjetoIdInvalido(int projetoIdInvalido)
        {
            Assert.Throws<DomainException>(() =>
                ImagemProjetoBuilder.Novo().ComProjetoId(projetoIdInvalido).Build()).ComMensagem(ImagemProjetoMsgErros.PROJETO_ID_INALIDO);
        }

        [Fact]
        public void DeveAlterarImagem()
        {
            var imagemEsperada = _faker.Image.Random.Bytes(8);
            var imagemProjeto = ImagemProjetoBuilder.Novo().Build();

            imagemProjeto.AlterarImagem(imagemEsperada);

            Assert.Equal(Convert.ToBase64String(imagemEsperada), Convert.ToBase64String(imagemProjeto.Imagem));
        }
    }
}
