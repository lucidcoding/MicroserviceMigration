using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Marathon.External.UI.ViewModels.Booking;
using Marathon.Domain.RepositoryContracts;
using System.Web.Mvc;
using Marathon.Domain.Requests;
using Marathon.External.UI.Security;
using Marathon.External.UI.Extensions;

namespace Marathon.External.UI.ViewModelMappers.Booking
{
    public class MakeViewModelMapper : IMakeViewModelMapper
    {
        private IVehicleRepository _vehicleRepository;
        private ICustomerRepository _customerRepository;
        private IUserProvider _userProvider;
        private IGetPendingForVehicleViewModelMapper _getPendingForVehicleViewModelMapper;

        public MakeViewModelMapper(
            IVehicleRepository vehicleRepository,
            ICustomerRepository customerRepository,
            IUserProvider userProvider,
            IGetPendingForVehicleViewModelMapper getPendingForVehicleViewModelMapper)
        {
            _vehicleRepository = vehicleRepository;
            _customerRepository = customerRepository;
            _userProvider = userProvider;
            _getPendingForVehicleViewModelMapper = getPendingForVehicleViewModelMapper;
        }

        public MakeViewModel New()
        {
            var viewModel = new MakeViewModel();
            viewModel.StartDate = DateTime.Now;
            viewModel.EndDate = DateTime.Now;
            Hydrate(viewModel);
            return viewModel;
        }

        public void Hydrate(MakeViewModel viewModel)
        {
            var vehicles = _vehicleRepository.GetAll();

            viewModel.VehicleOptions = new SelectList(
                vehicles.Select(vehicle => new SelectListItem 
                { 
                    Text = vehicle.RegistrationNumber + ": " + vehicle.Make + " " + vehicle.Model, 
                    Value = vehicle.Id.Value.ToString()
                }), "Value", "Text")
                .AddDefaultOption();

            if (viewModel.VehicleId.HasValue)
            {
                viewModel.PendingBookings = _getPendingForVehicleViewModelMapper.Map(viewModel.VehicleId.Value);
            }
            else
            {
                viewModel.PendingBookings = new List<GetPendingForVehicleViewModel>();
            }
        }

        public MakeBookingRequest Map(MakeViewModel viewModel)
        {
            var request = new MakeBookingRequest();
            request.StartDate = viewModel.StartDate;
            request.EndDate = viewModel.EndDate;
            request.Vehicle = viewModel.VehicleId.HasValue ? _vehicleRepository.GetById(viewModel.VehicleId.Value) : null;
            var username = _userProvider.GetUsername();
            request.Customer = _customerRepository.GetByUsername(username);
            return request;
        }
    }
}