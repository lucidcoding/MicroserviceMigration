using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marathon.Domain.Entities;

namespace Marathon.Domain.Requests
{
    public class CheckInForServicingRequest
    {
        public Vehicle Vehicle { get; set; }
        public decimal? Mileage { get; set; }
        public User CheckedInBy { get; set; }
    }
}
