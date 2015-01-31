using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Marathon.External.UI.ViewModels.Booking
{
    public class ReturnViewModel
    {
        [DisplayName("Booking Number")]
        public string BookingNumber { get; set; }

        public GetSummaryViewModel Summary { get; set; }

        [DisplayName("Mileage")]
        public int Mileage { get; set; }
    }
}