using Looh.Application.Common.Interfaces.Persistence;
using Looh.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Looh.Infrastructure.Persisntece
{
    public class UserRepository : IUserRepository
    {
        //private readonly LoohDbContext _context;

        private static readonly List<User> _users = new();

        public void Add(User user)
        {
            _users.Add(user);
        }

        public User? GetUserByEmail(string email)
        {
            return _users.SingleOrDefault(x => x.Email == email);        }

     
    }
}
