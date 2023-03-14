using System;

namespace Portfolio.Domain.Entities
{
    public class Habilidade : AbstractEntity
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public byte[] Imagem { get; private set; }
        public int DadosPortfolioId { get; private set; }


        public Habilidade()
        {
            
        }

        public Habilidade(string nome, string descricao, byte[] imagem, int dadosPortfolioId)
        {
            Nome = nome;
            Descricao = descricao;
            Imagem = imagem;
            DadosPortfolioId = dadosPortfolioId;
        }

        protected override void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
