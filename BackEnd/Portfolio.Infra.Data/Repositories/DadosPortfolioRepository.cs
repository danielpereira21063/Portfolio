using Portfolio.Domain.Entities;
using Portfolio.Domain.Interfaces.Repositories;
using Portfolio.Infra.Data.Context;
using System.Linq;

namespace Portfolio.Infra.Data.Repositories
{
    public class DadosPortfolioRepository : Repository<DadosPortfolio>, IDadosPortfolioRepository
    {
        public DadosPortfolioRepository(PortfolioContext context) : base(context)
        {
        }

        public DadosPortfolio ObterDadosPortfolio(int userId)
        {
            return Context.DadosPortfolios.FirstOrDefault(x => x.UserId == userId);
        }

    }
}
