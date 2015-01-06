using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Marathon.Domain.Requests;
using Marathon.Domain.Entities;

namespace Marathon.Domain.UnitTests.Entities.BookingTests
{
    [TestClass]
    public class ValidateMakeTests
    {
        [TestMethod]
        public void ValidRequestPasses()
        {
            var request = new MakeBookingRequest();

            var customer = new Customer()
            {
                Id = Guid.NewGuid(),
                FamilyName = "Blue"
            };

            var vehicle = new Vehicle() { 
                Id = Guid.NewGuid()
            };

            vehicle.Bookings = new List<Booking>()
            {
                new Booking() 
                {
                    StartDate = new DateTime(2050, 9, 1),
                    EndDate = new DateTime(2050, 9, 3),
                    Vehicle = vehicle
                }
            };

            request.Customer = customer;
            request.StartDate = new DateTime(2050, 10, 1);
            request.EndDate = new DateTime(2050, 10, 3);
            request.Vehicle = vehicle;

            var validationMessages = Booking.ValidateMake(request);

            Assert.AreEqual(0, validationMessages.Count);
        }

        [TestMethod]
        public void InvalidRequestFails()
        {
            var request = new MakeBookingRequest();

            var customer = new Customer()
            {
                Id = Guid.NewGuid(),
                FamilyName = "Blue"
            };

            var vehicle = new Vehicle()
            {
                Id = Guid.NewGuid()
            };

            vehicle.Bookings = new List<Booking>()
            {
                new Booking() 
                {
                    StartDate = new DateTime(2050, 9, 30),
                    EndDate = new DateTime(2050, 10, 2),
                    Vehicle = vehicle
                }
            };

            request.Customer = customer;
            request.StartDate = new DateTime(2050, 10, 1);
            request.EndDate = new DateTime(2050, 10, 3);
            request.Vehicle = vehicle;

            var validationMessages = Booking.ValidateMake(request);

            Assert.AreEqual(1, validationMessages.Count);
            Assert.IsTrue(validationMessages.Any(x => x.Text.Equals("Booking conflicts with existing bookings.")));
        }
    }
}
