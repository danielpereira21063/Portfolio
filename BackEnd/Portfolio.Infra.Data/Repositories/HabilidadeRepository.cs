using Portfolio.Domain.Entities;
using Portfolio.Domain.Interfaces.Repositories;
using Portfolio.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace Portfolio.Infra.Data.Repositories
{
    public class HabilidadeRepository : Repository<Habilidade>, IHabilidadeRepository
    {
        public HabilidadeRepository(PortfolioContext context) : base(context)
        {
        }

        public ICollection<Habilidade> ObterLista(int portfolioId)
        {
            return Context.Habilidades.Where(h => h.DadosPortfolioId == portfolioId).ToList();
        }
    }
}
