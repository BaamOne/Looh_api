using Looh.Application.Common.Interfaces.Persistence;
using Looh.Domain.Entities;

namespace Looh.Infrastructure.Persistence.User.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly LoohDbContext _dbContext;

        private static readonly List<Looh.Domain.Entities.User> _users = new();

        public UserRepository(LoohDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Looh.Domain.Entities.User user)
        {
            _dbContext.Add(user);

            _dbContext.SaveChanges();
        }

        public Looh.Domain.Entities.User? GetUserByEmail(string email)
        {
            return _users.SingleOrDefault(x => x.Email == email);
        }

    }
}
