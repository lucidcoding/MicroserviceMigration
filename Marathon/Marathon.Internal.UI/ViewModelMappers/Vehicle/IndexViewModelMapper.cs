using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Marathon.Domain.RepositoryContracts;
using Marathon.Internal.UI.ViewModels.Vehicle;
using Marathon.Domain.Constants;

namespace Marathon.Internal.UI.ViewModelMappers.Vehicle
{
    public class IndexViewModelMapper
    {
        private IVehicleRepository _vehicleRepository;

        public IndexViewModelMapper(
            IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public IndexViewModel Map()
        {
            var viewModel = new IndexViewModel();
            viewModel.Vehicles = new List<IndexViewModelVehicle>();
            var vehicles = _vehicleRepository.GetAll();

            foreach (var vehicle in vehicles)
            {
                var viewModelVehicle = new IndexViewModelVehicle();
                viewModelVehicle.VehicleId = vehicle.Id.Value;
                viewModelVehicle.RegistrationNumber = vehicle.RegistrationNumber;
                viewModelVehicle.Make = vehicle.Make;
                viewModelVehicle.Model = vehicle.Model;
                viewModelVehicle.Mileage = vehicle.Mileage;

                if (!vehicle.MaintenanceChecks.Any())
                {
                    viewModelVehicle.ShowNoMaintenanceCheckWarning = true;
                }

                if (vehicle.MileageSinceLastMaintenanceCheck.HasValue
                    && vehicle.MileageSinceLastMaintenanceCheck.Value > MaintenanceConstants.MileageBetweenChecks)
                {
                    viewModelVehicle.MileageClasses = "maintenance-alert";
                }

                viewModelVehicle.DaysSinceLastMaintenance = vehicle.DaysSinceLastMaintenanceCheck;

                if (vehicle.DaysSinceLastMaintenanceCheck.HasValue
                    && vehicle.DaysSinceLastMaintenanceCheck.Value > MaintenanceConstants.DurationBetweenChecks.Days)
                {
                    viewModelVehicle.DaysSinceLastMaintenanceClasses = "maintenance-alert";
                }

                viewModel.Vehicles.Add(viewModelVehicle);
            }

            return viewModel;
        }
    }
}