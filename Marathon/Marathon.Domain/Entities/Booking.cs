using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marathon.Domain.Common;

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
    }
}
