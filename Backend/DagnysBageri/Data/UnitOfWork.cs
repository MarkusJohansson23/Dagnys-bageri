using System.Threading.Tasks;
using DagnysBageri.Interfaces;
using DagnysBageri.Repositories;

namespace DagnysBageri.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UserContext _context;

        public UnitOfWork(UserContext context)
        {
            _context = context;
        }

        public UserRepository UserRepository => new UserRepository(_context);
        
        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
