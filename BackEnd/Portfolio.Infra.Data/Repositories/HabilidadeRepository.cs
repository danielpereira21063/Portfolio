using Portfolio.Domain.Entities;
using Portfolio.Domain.Interfaces.Repositories;
using Portfolio.Infra.Data.Context;

namespace Portfolio.Infra.Data.Repositories
{
    public class HabilidadeRepository : Repository<Habilidade>, IHabilidadeRepository
    {
        public HabilidadeRepository(PortfolioContext context) : base(context)
        {
        }
    }
}
