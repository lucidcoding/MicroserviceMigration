using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Marathon.Domain.UnitTests.Entities.VehicleTests
{
    [TestClass]
    public class RequiresMaintenanceTests
    {
        [TestMethod]
        public void VehicleThatDoesntRequireMaintenanceReturnsFalse()
        {
            var vehicle = new VehicleFactory().GetVehicle();
            Assert.IsFalse(vehicle.RequiresMaintenance);
        }

        [TestMethod]
        public void VehicleThatHasExceededDurationReturnsTrue()
        {
            var vehicle = new VehicleFactory().GetVehicle();
            vehicle.Bookings.ToList()[1].EndMileage = 30001;
            Assert.IsTrue(vehicle.RequiresMaintenance);
        }

        [TestMethod]
        public void VehicleThatHasExceededMileageReturnsTrue()
        {
            var vehicle = new VehicleFactory().GetVehicle();
            vehicle.MaintenanceChecks.ToList()[1].CheckedIn = DateTime.Now - new TimeSpan(366, 0, 0, 0);
            Assert.IsTrue(vehicle.RequiresMaintenance);
        }
    }
}
