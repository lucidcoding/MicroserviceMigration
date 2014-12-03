using System;
using Marathon.Domain.Common;
using Marathon.Domain.Entities;

namespace Marathon.Domain.RepositoryContracts
{
    public interface IRoleRepository : IRepository<Role, Guid>
    {
        Role GetByName(string roleName);
    }
}
