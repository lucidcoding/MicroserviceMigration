using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Marathon.External.UI.ValidationAttributes;

namespace Marathon.External.UI.ViewModels.Booking
{
    public class MakeViewModel
    {
        public SelectList VehicleOptions { get; set; }

        [DisplayName("Vehicle")]
        [Required]
        public Guid? VehicleId { get; set; }

        public IList<GetPendingForVehicleViewModel> PendingBookings { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Start Date")]
        [Required]
        [FutureDateOnly]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("End Date")]
        [Required]
        [FutureDateOnly]
        public DateTime? EndDate { get; set; }
    }
}