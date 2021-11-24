using System.Threading.Tasks;
using DagnysBageri.Repositories;

namespace DagnysBageri.Interfaces
{
    public interface IUnitOfWork
    {
        UserRepository UserRepository { get; }
        Task<bool> Complete();
    }
}
