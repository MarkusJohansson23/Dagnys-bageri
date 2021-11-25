using DagnysBageri.Data;
using DagnysBageri.Interfaces;
using DagnysBageri.Models;
using Microsoft.EntityFrameworkCore;
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

    public async Task<User> FindUserById(int id)
    {
      return await _context.Users.FindAsync(id);
    }

    public async Task<IList<User>> ListAllUsersAsync()
    {
      return await _context.Users.ToListAsync();
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
    public async Task<User> GetEmailAsync(string email)
    {
      return await _context.Users.FirstOrDefaultAsync(e => e.Email.ToLower() == email.ToLower());
    }
  }
}
