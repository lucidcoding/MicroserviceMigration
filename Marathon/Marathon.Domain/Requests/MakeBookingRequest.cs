using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marathon.Domain.Entities;

namespace Marathon.Domain.Requests
{
    public class MakeBookingRequest
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
