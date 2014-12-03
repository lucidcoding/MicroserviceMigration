using System;
using System.Linq;
using Marathon.Data.Common;
using Marathon.Domain.Entities;
using Marathon.Domain.RepositoryContracts;

namespace Marathon.Data.Repositories
{
    public class UserRepository : Repository<User, Guid>, IUserRepository
    {
        public UserRepository(IContextProvider contextProvider) :
            base(contextProvider)
        {
        }

        public User GetByUsername(string username)
        {
            return Context
                .Users
                .SingleOrDefault(user => user.Username == username);
        }
    }
}
