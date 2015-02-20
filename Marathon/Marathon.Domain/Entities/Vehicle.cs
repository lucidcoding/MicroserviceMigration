using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marathon.Domain.Common;
using Marathon.Domain.Constants;

namespace Marathon.Domain.Entities
{
    public class Vehicle : Entity<Guid>
    {
        public virtual string RegistrationNumber { get; set; }
        public virtual string Make { get; set; }
        public virtual string Model { get; set; }
        public virtual decimal PricePerMile { get; set; }
        public virtual Depot HomeDepot { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<MaintenanceCheck> MaintenanceChecks { get; set; }

        public virtual IList<Booking> GetConflictingBookings(DateTime startDate, DateTime endDate)
        {
            return Bookings.Where(booking =>
                (startDate >= booking.StartDate && startDate < booking.EndDate)
                || (endDate > booking.StartDate && endDate <= booking.EndDate)
                || (startDate <= booking.StartDate && endDate >= booking.EndDate))
                .ToList();
        }

        public virtual bool RequiresMaintenance
        {
            get
            {
                var lastBooking = Bookings
                    .Where(x => x.ReturnedOn.HasValue)
                    .OrderByDescending(x => x.ReturnedOn)
                    .FirstOrDefault();

                if(lastBooking == null)
                {
                    return false;
                }

                var lastMaintenanceCheck = MaintenanceChecks
                    .OrderByDescending(x => x.CheckedOn.Value)
                    .FirstOrDefault();

                var now = DateTime.Now;

                if(lastMaintenanceCheck == null)
                {
                    if (lastBooking.EndMileage > MaintenanceConstants.MileageBetweenChecks
                        || now > CreatedOn.Value + MaintenanceConstants.DurationBetweenChecks)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (lastBooking.EndMileage > lastMaintenanceCheck.Mileage + MaintenanceConstants.MileageBetweenChecks
                        || now > lastMaintenanceCheck.CheckedOn + MaintenanceConstants.DurationBetweenChecks)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
    }
}
