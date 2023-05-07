using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Domain.Entities
{
    public class Habilidade : AbstractEntity
    {

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public byte[] Imagem { get; private set; }
        public int DadosPortfolioId { get; private set; }

        [Column(TypeName = "MEDIUMBLOB")]
        public byte[] Logo { get; private set; }

        public int DadosPortfolioId { get; private set; }

        public Habilidade()
        {
            
        }

        public Habilidade(string nome, string descricao, byte[] logo, int dadosPortfolioId)
        {
            Nome = nome;
            Descricao = descricao;
            Logo = logo;
            DadosPortfolioId = dadosPortfolioId;
        }

        public void AlterarNome(string nome) => Nome = nome;
        public void AlterarDescricao(string descricao) => Descricao = descricao;
        public void AlterarLogo(byte[] logo) => Logo = logo;


        protected override void Validar()
        {
            throw new System.NotImplementedException();
        }
    }
}
