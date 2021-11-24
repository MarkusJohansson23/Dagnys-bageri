using DagnysBageri.Data;
using DagnysBageri.Interfaces;
using DagnysBageri.Models;
using Microsoft.EntityFrameworkCore;
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

    public async Task<bool> AddUserAsync(User user)
    {
      try
      {
        await _context.Users.AddAsync(user);
        return true;
      }
      catch
      {
        return false;

      }
    }

    public async Task<bool> RemoveUserAsync(User user)
    {
      try
      {
        _context.Remove(user);
        return await Task.FromResult<bool>(true);
      }
      catch
      {
        return await Task.FromResult<bool>(false);

      }
    }

    public async Task<bool> UpdateUserAsync(User user)
    {
      try
      {
        _context.Update(user);
        return await Task.FromResult<bool>(true);
      }
      catch
      {
        return await Task.FromResult<bool>(false);

      }
    }

    public async Task<IList<User>> ListAllUsersAsync()
    {
<<<<<<< HEAD
      return await _context.Users.ToListAsync();
=======
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

        public Task<User> FindUserById(int id)
        {
            throw new NotImplementedException();
        }
>>>>>>> b96b0e77d64bf659c24a4d01984f958010a8206e
    }

    public Task<User> FindUserById(int id)
    {
      throw new NotImplementedException();
    }
  }
}
