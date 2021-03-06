﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace Marathon.External.UI.ViewModels.Booking
{
    public class GetPendingForVehicleViewModel
    {
        public Guid VehicleId { get; set; }

        [DisplayName("Booking Number")]
        public string BookingNumber { get; set; }

        [DisplayName("Customer")]
        public string CustomerName { get; set; }

        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }

        [DisplayName("End Date")]
        public DateTime EndDate { get; set; }
    }
}