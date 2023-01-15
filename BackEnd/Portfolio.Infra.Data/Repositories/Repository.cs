using Portfolio.Domain.Entities;
using Portfolio.Domain.Interfaces.Repositories;
using Portfolio.Infra.Data.Context;
using System.Linq;

namespace Portfolio.Infra.Data.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : AbstractEntity
    {
        protected readonly PortfolioContext Context;

        protected Repository(PortfolioContext context)
        {
            Context = context;
        }

        public void Salvar(T entity)
        {
            Context.Add(entity);
        }

        public void Atualizar(T entity)
        {
            Context.Set<T>().Update(entity);
        }

        public T ObterPeloId(int id)
        {
            return Context.Set<T>().FirstOrDefault(x => x.Id == id);
        }
    }
}
