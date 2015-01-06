using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marathon.Domain.Common;

namespace Marathon.Domain.Entities
{
    public class MaintenanceCheck : Entity<Guid>
    {
        public virtual Guid? VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual DateTime? CheckedOn { get; set; }
        public virtual int? Mileage { get; set; }
    }
}
