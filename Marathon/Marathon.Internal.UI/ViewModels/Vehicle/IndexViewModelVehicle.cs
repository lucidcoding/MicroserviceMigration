using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marathon.Internal.UI.ViewModels.Vehicle
{
    public class IndexViewModelVehicle
    {
        public Guid VehicleId { get; set; }
        public string RegistrationNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public decimal? Mileage { get; set; }
        public string MileageClasses { get; set; }
        public bool ShowNoMaintenanceCheckWarning { get; set; }
        public int? DaysSinceLastMaintenance { get; set; }
        public string DaysSinceLastMaintenanceClasses { get; set; }
        public string VehicleStatus { get; set; }
    }
}