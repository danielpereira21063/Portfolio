using Microsoft.EntityFrameworkCore;
using Portfolio.Domain.Entities;
using Portfolio.Domain.Interfaces.Repositories;
using Portfolio.Infra.Data.Context;
using System.Linq;

namespace Portfolio.Infra.Data.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : AbstractEntity
    {
        protected readonly PortfolioContext Context;
        protected readonly DbSet<T> DbSet;

        protected Repository(PortfolioContext context)
        {
            Context = context;
            DbSet = Context.Set<T>();
        }

        public void Salvar(T entity)
        {
            DbSet.Add(entity);
            Context.SaveChanges();
        }

        public void Atualizar(T entity)
        {
            DbSet.Update(entity);
        }

        public T ObterPeloId(int id)
        {
            return DbSet.FirstOrDefault(x => x.Id == id);
        }
    }
}
