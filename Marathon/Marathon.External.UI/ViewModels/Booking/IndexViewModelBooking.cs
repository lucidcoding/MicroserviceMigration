using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marathon.External.UI.ViewModels.Booking
{
    public class IndexViewModelBooking
    {
        public Guid Id { get; set; }
        public string BookingNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string MakeAndModel { get; set; }
        public decimal Total { get; set; }
    }
}