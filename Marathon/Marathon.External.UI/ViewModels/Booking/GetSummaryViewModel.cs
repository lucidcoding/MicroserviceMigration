using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace Marathon.External.UI.ViewModels.Booking
{
    public class GetSummaryViewModel
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