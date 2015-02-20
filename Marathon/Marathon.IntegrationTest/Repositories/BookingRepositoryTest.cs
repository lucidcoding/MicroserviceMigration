using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Marathon.IntegrationTests.Common;
using Marathon.Domain.Entities;
using Marathon.Domain.Requests;
using Marathon.Domain.RepositoryContracts;
using Marathon.Domain.Constants;
using Marathon.IntegrationTest.Common;
using Ninject;
using Ninject.Activation;
using Marathon.Data.Common;

namespace Marathon.IntegrationTest.Repositories
{
    [TestClass]
    public class BookingRepositoryTest
    {
        private IContextProvider _contextProvider;
        private IBookingRepository _bookingRepository;
        private IUserRepository _userRepository;
        private IVehicleRepository _vehicleRepository;

        [TestInitialize]
        public void SetUp()
        {
            _contextProvider = TestRegistry.Kernel.Get<IContextProvider>();
            _bookingRepository = TestRegistry.Kernel.Get<IBookingRepository>();
            _userRepository = TestRegistry.Kernel.Get<IUserRepository>();
            _vehicleRepository = TestRegistry.Kernel.Get<IVehicleRepository>();
            ScriptRunner.RunScript();
        }

        [TestMethod]
        public void CanAddBooking()
        {
            Guid bookingId;

            var makeBookingRequest = new MakeBookingRequest()
            {
                StartDate = new DateTime(2015, 01, 12),
                EndDate = new DateTime(2015, 01, 16)
            };

            using (_contextProvider)
            {
                var user = _userRepository.GetById(UserIds.Test);
                makeBookingRequest.Vehicle = _vehicleRepository.GetById(VehicleIds.SF59QRT);

                makeBookingRequest.Customer = Customer.Register(new RegisterCustomerRequest()
                {
                    FamilyName = "Green",
                    GivenName = "Gary",
                    Address1 = "3 Green Road",
                    Address2 = "Greenton",
                    Address3 = "Greenshire",
                    PostCode = "GN1 1AA",
                    ApplicationUser = user
                });

                var booking = Booking.Make(makeBookingRequest);
                _bookingRepository.Save(booking);
                bookingId = booking.Id.Value;
                _contextProvider.SaveChanges();
            }

            using (_contextProvider)
            {
                var allBookings = _bookingRepository.GetAll();
                var storedBooking = _bookingRepository.GetById(bookingId);
                Assert.AreEqual(1, allBookings.Count);
                Assert.IsNotNull(storedBooking.Id);
                Assert.IsNotNull(storedBooking.BookingNumber);
                Assert.AreEqual(makeBookingRequest.EndDate, storedBooking.EndDate.Value);
                Assert.AreEqual(makeBookingRequest.EndDate, storedBooking.EndDate.Value);
                Assert.AreEqual(makeBookingRequest.Customer.User.Id.Value, storedBooking.CreatedBy.Id.Value);
                Assert.AreEqual("Green", storedBooking.Customer.FamilyName);
                Assert.AreEqual("Gary", storedBooking.Customer.GivenName);
                Assert.AreEqual("Ford", storedBooking.Vehicle.Make);
                Assert.AreEqual("Transit", storedBooking.Vehicle.Model);
            }
        }
    }
}
