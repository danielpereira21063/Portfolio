using Portfolio.Infra.Data.Context;
using System.Threading.Tasks;

namespace Portfolio.Infra.Data.Transaction
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PortfolioContext _context;

        public UnitOfWork(PortfolioContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public async Task<bool> CommitAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
