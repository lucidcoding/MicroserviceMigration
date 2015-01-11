using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace Marathon.UI.ViewModels.Booking
{
    public class GetPendingForVehicleViewModel
    {
        public Guid VehicleId { get; set; }

        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }

        [DisplayName("End Date")]
        public DateTime EndDate { get; set; }
    }
}