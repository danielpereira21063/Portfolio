using Portfolio.Domain.Validacoes;
using Portfolio.Domain.Validacoes.MensagemDeErros;
using System.Collections.Generic;

namespace Portfolio.Domain.Entities
{
    public class Projeto : AbstractEntity
    {
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public string Url { get; private set; }
        public string UrlGitHub { get; private set; }
        public bool Inativo { get; private set; }
        public int DadosPortfolioId { get; private set; }
        public DadosPortfolio DadosPortfolio { get; private set; }
        public ICollection<ImagemProjeto> ImagensProjeto { get; private set; }

        public Projeto()
        {

        }

        public Projeto(string titulo, string descricao, string url, string urlGitHub, int dadosPortfolioId)
        {
            Titulo = titulo;
            Descricao = descricao;
            Url = url;
            UrlGitHub = urlGitHub;
            DadosPortfolioId = dadosPortfolioId;

            Validar();
        }

        public void AlterarTitulo(string titulo) => Titulo = titulo;
        public void AlterarDescricao(string descricao) => Descricao = descricao;
        public void AlterarUrl(string url) => Url = url;
        public void AlterarUrlGitHub(string urlGithub) => UrlGitHub = urlGithub;
        public void Inativar() => Inativo = true;
        public void Ativar() => Inativo = false;

        protected override void Validar()
        {
            ValidadorDeEntidade.Novo()
                .Quando(string.IsNullOrEmpty(Titulo), ProjetoMsgErros.TITULO_INVALIDO)
                .Quando(string.IsNullOrEmpty(Descricao), ProjetoMsgErros.DESCRICAO_INVALIDA)
                .Quando(!ValidadorDeExpressao.ValidarUrl(Url) || string.IsNullOrEmpty(Url), ProjetoMsgErros.URL_INVALIDA)
                .Quando(!ValidadorDeExpressao.ValidarUrl(UrlGitHub) || string.IsNullOrEmpty(UrlGitHub), ProjetoMsgErros.URL_GITHUB_INVALIDA)
                .Quando(DadosPortfolioId <= 0, ProjetoMsgErros.PORTFOLIO_ID_INVALIDO)
                .LancarExcecoesSeExistir();
        }
    }
}
