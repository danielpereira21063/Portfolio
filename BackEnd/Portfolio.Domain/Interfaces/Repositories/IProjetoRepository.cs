using Portfolio.Domain.Entities;
using System.Collections;
using System.Collections.Generic;

namespace Portfolio.Domain.Interfaces.Repositories
{
    public interface IProjetoRepository : IRepository<Projeto>
    {
        ICollection<Projeto> ObterLista(int dadosPortfolioId, bool obterInativos = false);
    }
}
