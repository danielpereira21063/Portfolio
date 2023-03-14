using Portfolio.Domain.Entities;
using System.Collections.Generic;

namespace Portfolio.Domain.Interfaces.Repositories
{
    public interface IHabilidadeRepository
    {
        ICollection<Habilidade> ObterLista(int portfolioId);
    }
}
