using DagnysBageri.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DagnysBageri.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> AddUserAsync(User user);
        Task<bool> RemoveUserAsync(User user);
        Task<bool> UpdateUserAsync (User user);
        Task<IList<User>> ListAllUsersAsync();
        Task<User> FindUserById(int id);
    }
}