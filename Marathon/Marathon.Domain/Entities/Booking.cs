using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marathon.Domain.Common;
using Marathon.Domain.Requests;
using Marathon.Domain.InfrastructureContracts;

namespace Marathon.Domain.Entities
{
    public class Booking : Entity<Guid>
    {
        public virtual string BookingNumber { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual decimal? StartMileage { get; set; }
        public virtual decimal? EndMileage { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual DateTime? CollectedOn { get; set; }
        public virtual DateTime? ReturnedOn { get; set; }
        public virtual decimal Total { get; set; }

        public static ValidationMessageCollection ValidateMake(MakeBookingRequest request)
        {
            var validationMessages = new ValidationMessageCollection();

            if (!request.StartDate.HasValue || request.StartDate.Value == default(DateTime))
            {
                validationMessages.AddError("StartDate", "Start date is required.");
            }
            else
            {
                if (request.StartDate.Value < DateTime.Now.Date) validationMessages.AddError("StartDate", "Start date must not be in the past.");
            }

            if (!request.EndDate.HasValue || request.EndDate.Value == default(DateTime))
            {
                validationMessages.AddError("EndDate", "End date is required.");
            }
            else
            {
                if (request.EndDate.Value < DateTime.Now) validationMessages.AddError("EndDate", "End date must not be in the past.");
            }

            if (request.StartDate.HasValue && request.EndDate.HasValue)
            {
                if (request.EndDate.Value < request.StartDate.Value) validationMessages.AddError("EndDate", "End date must not be before start date.");
            }

            if (request.Vehicle == null) validationMessages.AddError("Vehicle", "Vehicle is required.");
            if (request.Customer == null) validationMessages.AddError("Customer", "Customer is required.");

            if (request.Vehicle != null
                && request.StartDate.HasValue
                && request.EndDate.HasValue
                && request.Vehicle.GetConflictingBookings(request.StartDate.Value, request.EndDate.Value).Any())
            {
                validationMessages.AddError("", "Booking conflicts with existing bookings.");
            }

            return validationMessages;
        }

        public static Booking Make(MakeBookingRequest request)
        {
            var booking = new Booking();
            booking.Id = Guid.NewGuid();
            booking.BookingNumber = request.Customer.FamilyName.ToUpper() + DateTime.Now.ToString("yyMMddHHmmss");
            booking.StartDate = request.StartDate.Value;
            booking.EndDate = request.EndDate.Value;
            booking.Customer = request.Customer;
            booking.CreatedBy = request.Customer.User;
            booking.Vehicle = request.Vehicle;
            var totalDays = (request.EndDate.Value - request.StartDate.Value).Days + 1;
            booking.Total = totalDays * request.Vehicle.PricePerDay;
            return booking;
        }

        public virtual ValidationMessageCollection ValidateCollect(CollectBookingRequest request)
        {
            var validationMessages = new ValidationMessageCollection();

#warning Check it's on the same day?

            return validationMessages;
        }

        public virtual void Collect(CollectBookingRequest request)
        {
            var now = DateTime.Now;
            CollectedOn = now;
            StartMileage = request.Mileage.Value;
            LastModifiedOn = now;
            LastModifiedBy = request.LoggedBy;
        }

        public virtual ValidationMessageCollection ValidateReturn(ReturnBookingRequest request)
        {
            var validationMessages = new ValidationMessageCollection();

#warning Check it's actually out?

            return validationMessages;
        }

        public virtual void Return(ReturnBookingRequest request)
        {
            var now = DateTime.Now;
            ReturnedOn  = now;
            EndMileage = request.Mileage.Value;
            LastModifiedOn = now;
            LastModifiedBy = request.LoggedBy;
        }
    }
}
