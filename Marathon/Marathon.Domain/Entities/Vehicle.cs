using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marathon.Domain.Common;

namespace Marathon.Domain.Entities
{
    public class Vehicle : Entity<Guid>
    {
        public virtual string RegistrationNumber { get; set; }
        public virtual string Make { get; set; }
        public virtual string Model { get; set; }
        public virtual decimal PricePerMile { get; set; }
        public virtual Guid? HomeDepotId { get; set; }
        public virtual Depot HomeDepot { get; set; }
    }
}
