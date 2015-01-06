using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marathon.Domain.Entities;

namespace Marathon.Domain.UnitTests.Entities.VehicleTests
{
    public class VehicleFactory
    {
        public Vehicle GetVehicle()
        {
            var vehicle = new Vehicle();
            vehicle.Id = Guid.NewGuid();
            vehicle.CreatedOn = new DateTime(2010, 1, 1);
            var now = DateTime.Now;

            vehicle.Bookings = new List<Booking>()
            {
                new Booking()
                {
                    Id = Guid.NewGuid(),
                    ReturnedOn = new DateTime(2010, 1, 2),
                    EndMileage = 19999
                },
                new Booking()
                {
                    Id = Guid.NewGuid(),
                    ReturnedOn = now - new TimeSpan(100, 0, 0, 0),
                    EndMileage = 29999
                }
            };

            vehicle.MaintenanceChecks = new List<MaintenanceCheck>()
            {
                new MaintenanceCheck()
                {
                    Id = Guid.NewGuid(),
                    Mileage = 10000,
                    CheckedOn = now - new TimeSpan(729, 0, 0, 0)
                },
                new MaintenanceCheck()
                {
                    Id = Guid.NewGuid(),
                    Mileage = 20000,
                    CheckedOn = now - new TimeSpan(364, 0, 0, 0)
                }
            };

            return vehicle;
        }
    }
}
