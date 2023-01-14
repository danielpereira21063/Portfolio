using Portfolio.Domain.Entities;

namespace Portfolio.Domain.Interfaces.Repositories
{
    public interface IDadosPortfolioRepository : IRepository<DadosPortfolio>
    {
        DadosPortfolio ObterDadosPortfolio(int userId);
    }
}
