using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marathon.External.UI.ViewModels.Booking
{
    public class IndexViewModel
    {
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public IList<IndexViewModelBooking> Bookings { get; set; }
    }
}