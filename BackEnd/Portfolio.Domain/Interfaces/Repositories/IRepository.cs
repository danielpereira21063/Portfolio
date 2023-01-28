using Portfolio.Domain.Entities;
using System.Collections;
using System.Collections.Generic;

namespace Portfolio.Domain.Interfaces.Repositories
{
    public interface IRepository<Entity> where Entity : AbstractEntity
    {
        void Adicionar(Entity entity);
        void Atualizar(Entity entity);
        Entity ObterPeloId(int id);
    }
}
