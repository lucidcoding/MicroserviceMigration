using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marathon.Domain.Common;
using Marathon.Domain.Requests;

namespace Marathon.Domain.Entities
{
    public class Booking : Entity<Guid>
    {
        public virtual string BookingNumber { get; set; }
        public virtual DateTime? StartDate { get; set; }
        public virtual DateTime? EndDate { get; set; }
        public virtual decimal StartMileage { get; set; }
        public virtual decimal EndMileage { get; set; }
        public virtual Guid? VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual Guid? CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public static Booking Make(MakeBookingRequest request)
        {
            var booking = new Booking();
            booking.Id = Guid.NewGuid();
            booking.BookingNumber = request.Customer.FamilyName.ToUpper() + DateTime.Now.ToString("yyMMddHHmmss");
            booking.StartDate = request.StartDate;
            booking.EndDate = request.EndDate;
            booking.Customer = request.Customer;
            booking.CreatedBy = request.Customer.User;
            booking.Vehicle = request.Vehicle;
            return booking;
        }
    }
}
