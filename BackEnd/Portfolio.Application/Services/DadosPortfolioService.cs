using AutoMapper;
using Portfolio.Application.DTOs.InputModels;
using Portfolio.Application.Models.DTOs;
using Portfolio.Application.Services.Interfaces;
using Portfolio.Domain.Entities;
using Portfolio.Domain.Interfaces.Repositories;

namespace Portfolio.Application.Services
{
    public class DadosPortfolioService : Service, IDadosPortfolioService
    {
        private readonly IDadosPortfolioRepository _dadosPortfolioRepository;

        public DadosPortfolioService(IDadosPortfolioRepository dadosPortfolioRepository, IMapper mapper) : base(mapper)
        {
            _dadosPortfolioRepository = dadosPortfolioRepository;
        }

        public DadosPortfolioDto ObterDadosPortfolio(int userId)
        {
            var dadosPortfolio = _dadosPortfolioRepository.ObterDadosPortfolio(userId);
            return Mapper.Map<DadosPortfolioDto>(dadosPortfolio);
        }

        public DadosPortfolioDto Salvar(int userId, DadosPortfolioInputModel model)
        {
            var dadosPortfolio = _dadosPortfolioRepository.ObterDadosPortfolio(userId);

            if (dadosPortfolio != null)
            {
                dadosPortfolio.AlterarNomeComleto(model.NomeCompleto);
                dadosPortfolio.AlterarMensagemDeApresentacao(model.MensagemApresentacao);
                dadosPortfolio.AlterarUrlLinkedin(model.LinkedinURL);
                dadosPortfolio.AlterarUrlFacebook(model.FacebookURL);
                dadosPortfolio.AlterarUrlTwitter(model.TwitterURL);
                dadosPortfolio.AlterarUrlYoutube(model.YoutubeURL);
                dadosPortfolio.AlterarWhatsapp(model.WhatsApp);
                dadosPortfolio.AlterarEmail(model.Email);

                _dadosPortfolioRepository.Atualizar(dadosPortfolio);

                return Mapper.Map<DadosPortfolioDto>(dadosPortfolio);
            }

            dadosPortfolio = new DadosPortfolio(
                                 model.NomeCompleto, model.MensagemApresentacao, model.ImagemPerfil, model.LinkedinURL, model.FacebookURL,
                                 model.TwitterURL, model.InstagramURL, model.YoutubeURL, model.WhatsApp, model.Email, userId);

            _dadosPortfolioRepository.Adicionar(dadosPortfolio);

            return Mapper.Map<DadosPortfolioDto>(dadosPortfolio);
        }
    }
}
