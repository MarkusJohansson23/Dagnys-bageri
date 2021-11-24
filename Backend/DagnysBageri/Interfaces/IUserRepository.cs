using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DagnysBageri.Models;

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