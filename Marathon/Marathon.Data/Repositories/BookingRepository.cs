using System;
using System.Linq;
using Marathon.Data.Common;
using Marathon.Domain.Entities;
using Marathon.Domain.RepositoryContracts;

namespace Marathon.Data.Repositories
{
    public class BookingRepository : Repository<Booking, Guid>, IBookingRepository
    {
        public BookingRepository(IContextProvider contextProvider) :
            base(contextProvider)
        {
        }
    }
}
