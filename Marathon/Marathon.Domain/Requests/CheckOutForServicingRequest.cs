using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marathon.Domain.Entities;

namespace Marathon.Domain.Requests
{
    public class CheckOutForServicingRequest
    {
        public User CheckedOutBy { get; set; }
    }
}
