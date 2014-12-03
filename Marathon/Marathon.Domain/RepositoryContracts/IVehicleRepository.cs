using System;
using Marathon.Domain.Common;
using Marathon.Domain.Entities;

namespace Marathon.Domain.RepositoryContracts
{
    public interface IVehicleRepository : IRepository<Vehicle, Guid>
    {
    }
}

