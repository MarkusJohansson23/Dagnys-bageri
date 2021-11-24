using System.Threading.Tasks;
using DagnysBageri.Repositories;

namespace DagnysBageri.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        Task<bool> Complete();
    }
}
