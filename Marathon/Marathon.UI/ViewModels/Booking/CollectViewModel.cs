using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace Marathon.UI.ViewModels.Booking
{
    public class CollectViewModel
    {
        [DisplayName("Booking Number")]
        public string BookingNumber { get; set; }

        public CollectDetailsViewModel Details { get; set; }
    }
}