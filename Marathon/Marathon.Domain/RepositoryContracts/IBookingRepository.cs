using System;
using System.Collections.Generic;
using Marathon.Domain.Common;
using Marathon.Domain.Entities;

namespace Marathon.Domain.RepositoryContracts
{
    public interface IBookingRepository : IRepository<Booking, Guid>
    {
        IList<Booking> GetPendingForVehicle(Guid vehicleId);
    }
}
