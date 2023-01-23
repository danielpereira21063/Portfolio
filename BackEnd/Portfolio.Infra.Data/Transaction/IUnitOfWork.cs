using System.Threading.Tasks;

namespace Portfolio.Infra.Data.Transaction
{
    public interface IUnitOfWork
    {
        bool Commit();
        Task<bool> CommitAsync();
    }
}
