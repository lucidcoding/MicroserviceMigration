using System;
using System.Linq;
using Marathon.Data.Common;
using Marathon.Domain.Entities;
using Marathon.Domain.RepositoryContracts;
using System.Collections.Generic;
using Marathon.Domain.Constants;

namespace Marathon.Data.Repositories
{
    public class VehicleRepository : Repository<Vehicle, Guid>, IVehicleRepository
    {
        public VehicleRepository(IContextProvider contextProvider) :
            base(contextProvider)
        {
        }
    }
}
