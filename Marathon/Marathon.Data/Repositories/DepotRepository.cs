using System;
using System.Linq;
using Marathon.Data.Common;
using Marathon.Domain.Entities;
using Marathon.Domain.RepositoryContracts;

namespace Marathon.Data.Repositories
{
    public class DepotRepository : Repository<Depot, Guid>, IDepotRepository
    {
        public DepotRepository(IContextProvider contextProvider) :
            base(contextProvider)
        {
        }
    }
}
