using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Portfolio.Domain.Validacoes;
using Portfolio.Domain.Validacoes.MensagemDeErros;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Domain.Entities
{
    public class ImagemProjeto : AbstractEntity
    {
        [Column(TypeName = "MEDIUMBLOB")]
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

            Validar();
        }

        public void AlterarImagem(byte[] imagem) => Imagem = imagem;
        public void DefinirComoPrincipal() => Principal = true;
        public void DefinirComoNaoPrincipal() => Principal = false;

        protected override void Validar()
        {
            ValidadorDeEntidade.Novo()
                .Quando((Imagem?.Length ?? 0) == 0 || Imagem == null, ImagemProjetoMsgErros.IMAGEM_INVALIDA)
                .Quando(ProjetoId <= 0, ImagemProjetoMsgErros.PROJETO_ID_INALIDO)
                .LancarExcecoesSeExistir();
        }
    }
}
