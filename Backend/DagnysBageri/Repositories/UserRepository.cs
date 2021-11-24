using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DagnysBageri.Data;

namespace DagnysBageri.Repositories
{
    public class UserRepository
    {
        private readonly UserContext _context;

        public UserRepository(UserContext context)
        {
            _context = context;
        }
    }
}
