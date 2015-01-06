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
    public class MakeTests
    {
        [TestMethod]
        public void CanMakeBooking()
        {
            var request = new MakeBookingRequest();

            var customer = new Customer() { 
                Id = Guid.NewGuid(),
                FamilyName = "Blue"
            };

            var vehicle = new Vehicle() { Id = Guid.NewGuid() };
            request.Customer = customer;
            request.StartDate = new DateTime(2050, 10, 1);
            request.EndDate = new DateTime(2050, 10, 3);
            request.Vehicle = vehicle;

            var booking = Booking.Make(request);

            Assert.IsNotNull(booking.Id);
            Assert.AreNotEqual(default(Guid), booking.Id.Value);
            Assert.IsNotNull(booking.BookingNumber);
            Assert.AreEqual(request.StartDate, booking.StartDate);
            Assert.AreEqual(request.EndDate, booking.EndDate);
            Assert.AreSame(customer, booking.Customer);
            Assert.AreSame(vehicle, booking.Vehicle);
        }
    }
}
