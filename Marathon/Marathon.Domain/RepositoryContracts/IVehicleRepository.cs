using System;
using Marathon.Domain.Common;
using Marathon.Domain.Entities;
using System.Collections.Generic;

namespace Marathon.Domain.RepositoryContracts
{
    public interface IVehicleRepository : IRepository<Vehicle, Guid>
    {
    }
}

