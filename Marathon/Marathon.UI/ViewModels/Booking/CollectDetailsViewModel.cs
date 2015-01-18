using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace Marathon.UI.ViewModels.Booking
{
    public class CollectDetailsViewModel
    {
        public Guid BookingId { get; set; }

        [DisplayName("Customer Name:")]
        public string CustomerName { get; set; }

        [DisplayName("Start Date:")]
        public DateTime StartDate { get; set; }

        [DisplayName("End Date:")]
        public DateTime EndDate { get; set; }
    }
}