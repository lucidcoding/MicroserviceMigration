using System;
using System.Linq;
using Marathon.Data.Common;
using Marathon.Domain.Entities;
using Marathon.Domain.RepositoryContracts;
using System.Collections.Generic;

namespace Marathon.Data.Repositories
{
    public class BookingRepository : Repository<Booking, Guid>, IBookingRepository
    {
        public BookingRepository(IContextProvider contextProvider) :
            base(contextProvider)
        {
        }

        public IList<Booking> GetPendingForVehicle(Guid vehicleId)
        {
            return Context
                .Bookings
                .Where(booking => booking.StartDate > DateTime.Now && booking.Vehicle.Id == vehicleId)
                .OrderByDescending(booking => booking.StartDate)
                .ToList();
        }

        public Booking GetByBookingNumber(string bookingNumber)
        {
            return Context
                .Bookings
                .Where(booking => booking.BookingNumber == bookingNumber)
                .SingleOrDefault();
        }
    }
}
