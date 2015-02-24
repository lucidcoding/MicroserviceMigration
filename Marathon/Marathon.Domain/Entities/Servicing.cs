using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marathon.Domain.Common;
using Marathon.Domain.Requests;
using Marathon.Domain.Enumerations;

namespace Marathon.Domain.Entities
{
    public class Servicing : Entity<Guid>
    {
        public virtual Vehicle Vehicle { get; set; }
        public virtual DateTime CheckedIn { get; set; }
        public virtual DateTime? CheckedOut { get; set; }
        public virtual int? Mileage { get; set; }

        public static ValidationMessageCollection ValidateCheckIn(CheckInForServicingRequest request)
        {
            var validationMessages = new ValidationMessageCollection();
            if (request.Vehicle == null) validationMessages.AddError("Vehicle", "Vehicle is required.");
            if (!request.Mileage.HasValue) validationMessages.AddError("Mileage", "Mileage is required.");
            if (request.CheckedInBy == null) validationMessages.AddError("User is not set.");

            if (request.Vehicle.Status != VehicleStatus.InDepot) 
                validationMessages.AddError("Vehicle", string.Format("Vehicle must be in the '{0}' state.", VehicleStatus.InDepot));

            return validationMessages;
        }

        public static Servicing CheckIn(CheckInForServicingRequest request)
        {
            var servicing = new Servicing();
            var now = DateTime.Now;
            servicing.Id = Guid.NewGuid();
            servicing.Vehicle = request.Vehicle;
            servicing.CheckedIn = now;
            servicing.Vehicle.Status = VehicleStatus.UndergoingMaintenance;
            servicing.CreatedOn = now;
            servicing.CreatedBy = request.CheckedInBy;
            return servicing;
        }

        public virtual ValidationMessageCollection ValidateCheckOut(CheckOutForServicingRequest request)
        {
            var validationMessages = new ValidationMessageCollection();
            if (request.CheckedOutBy == null) validationMessages.AddError("User is not set.");

            if (Vehicle.Status != VehicleStatus.InDepot)
                validationMessages.AddError("Vehicle", string.Format("Vehicle must be in the '{0}' state.", VehicleStatus.UndergoingMaintenance));

            return validationMessages;
        }

        public virtual void CheckOut(CheckOutForServicingRequest request)
        {
            var servicing = new Servicing();
            var now = DateTime.Now;
            Vehicle.Status = VehicleStatus.InDepot;
            CheckedOut = now;
            LastModifiedOn = now;
            LastModifiedBy = request.CheckedOutBy;
        }
    }
}
