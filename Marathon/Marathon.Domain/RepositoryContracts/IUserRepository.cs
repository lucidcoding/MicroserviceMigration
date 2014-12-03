using System;
using Marathon.Domain.Common;
using Marathon.Domain.Entities;

namespace Marathon.Domain.RepositoryContracts
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        User GetByUsername(string userName);
    }
}

