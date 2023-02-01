using Portfolio.Domain.Entities;
using Portfolio.Domain.Interfaces.Repositories;
using Portfolio.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace Portfolio.Infra.Data.Repositories
{
    public class ProjetoRepository : Repository<Projeto>, IProjetoRepository
    {
        public ProjetoRepository(PortfolioContext context) : base(context)
        {
        }

        public ICollection<Projeto> ObterLista(int dadosPortfolioId, bool obterInativos = false, string termoBusca = "")
        {
            var query = Context.Projetos
                .OrderBy(x => x.Titulo)
                .Where(x => x.DadosPortfolioId == dadosPortfolioId && (x.Titulo.Contains(termoBusca) || x.Descricao.Contains(termoBusca)));

            if (!obterInativos) query = query.Where(x => !x.Inativo);

            return query.ToList();
        }
    }
}
