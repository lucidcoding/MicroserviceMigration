using System;
using System.Linq;
using Marathon.Data.Common;
using Marathon.Domain.Entities;
using Marathon.Domain.RepositoryContracts;

namespace Marathon.Data.Repositories
{
    public class RoleRepository : Repository<Role, Guid>, IRoleRepository
    {
        public RoleRepository(IContextProvider contextProvider) :
            base(contextProvider)
        {
        }

        public Role GetByName(string roleName)
        {
            return Context
                .Roles
                .SingleOrDefault(role => role.RoleName == roleName);
        }
    }
}
