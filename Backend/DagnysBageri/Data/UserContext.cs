using DagnysBageri.Models;
using Microsoft.EntityFrameworkCore;

namespace DagnysBageri.Data
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserContext(DbContextOptions options) : base(options)
        {

        }
    }
}
