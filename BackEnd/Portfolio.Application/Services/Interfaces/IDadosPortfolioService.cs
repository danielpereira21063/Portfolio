using Portfolio.Application.DTOs.InputModels;
using Portfolio.Application.Models.DTOs;

namespace Portfolio.Application.Services.Interfaces
{
    public interface IDadosPortfolioService
    {
        DadosPortfolioDto Salvar(int userId, DadosPortfolioInputModel model);
        DadosPortfolioDto ObterDadosPortfolio(int userId);
    }
}
