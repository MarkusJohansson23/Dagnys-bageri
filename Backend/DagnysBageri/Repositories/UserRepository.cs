using DagnysBageri.Data;
using DagnysBageri.Interfaces;
using DagnysBageri.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DagnysBageri.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;

        public UserRepository(UserContext context)
        {
            _context = context;
        }

        public Task<bool> AddUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<IList<User>> ListAllUsersAsync()
        {
            throw new NotImplementedException();
        }
    }
}
