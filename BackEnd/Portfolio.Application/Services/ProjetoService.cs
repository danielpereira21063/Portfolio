using AutoMapper;
using Portfolio.Application.Models.DTOs;
using Portfolio.Application.Models.InputModels;
using Portfolio.Application.Services.Interfaces;
using Portfolio.Domain.Entities;
using Portfolio.Domain.Interfaces.Repositories;
using Portfolio.Domain.Validacoes.Exceptions;

namespace Portfolio.Application.Services
{
    public class ProjetoService : Service, IProjetoService
    {
        private readonly IDadosPortfolioRepository _dadosPortfolioRepository;
        private readonly IProjetoRepository _projetoRepository;

        public ProjetoService(IMapper mapper, IProjetoRepository projetoRepository, IDadosPortfolioRepository dadosPortfolioRepository) : base(mapper)
        {
            _projetoRepository = projetoRepository;
            _dadosPortfolioRepository = dadosPortfolioRepository;
        }

        public ProjetoDto AlterarStatus(int usuarioId, int projetoId)
        {
            try
            {
                var projeto = _projetoRepository.ObterPeloId(projetoId);

                if (projeto == null) throw new DomainException("Projeto não encontrado");

                var dadosPortfolio = _dadosPortfolioRepository.ObterDadosPortfolio(usuarioId);

                if (projeto.DadosPortfolioId != dadosPortfolio.Id) throw new DomainException("Projeto não encontrado");


                if (projeto.Inativo)
                {
                    projeto.Ativar();
                }
                else
                {
                    projeto.Inativar();
                }

                _projetoRepository.Atualizar(projeto);

                return Mapper.Map<ProjetoDto>(projeto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ICollection<ProjetoDto> ObterLista(int dadosPortfolioId, bool obterInativos)
        {
            var projetos = _projetoRepository.ObterLista(dadosPortfolioId, obterInativos);

            return Mapper.Map<ICollection<ProjetoDto>>(projetos);
        }

        public ProjetoDto ObterPeloId(int projetoId)
        {
            var projeto = _projetoRepository.ObterPeloId(projetoId);

            return Mapper.Map<ProjetoDto>(projeto);
        }

        public ProjetoDto Salvar(int usuarioId, ProjetoInputModel model)
        {
            try
            {
                var projeto = _projetoRepository.ObterPeloId(model.Id);

                if (projeto == null)
                {
                    var dadosPortfolio = _dadosPortfolioRepository.ObterDadosPortfolio(usuarioId);

                    projeto = new Projeto(model.Titulo, model.Descricao, model.Url, model.UrlGitHub, dadosPortfolio.Id);

                    _projetoRepository.Adicionar(projeto);
                }
                else
                {
                    projeto.AlterarTitulo(model.Titulo);
                    projeto.AlterarDescricao(model.Descricao);
                    projeto.AlterarUrl(model.Url);
                    projeto.AlterarUrlGitHub(model.UrlGitHub);
                    _projetoRepository.Atualizar(projeto);
                }

                return Mapper.Map<ProjetoDto>(projeto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
