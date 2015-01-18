using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Marathon.Domain.RepositoryContracts;
using Marathon.UI.ViewModels.Booking;

namespace Marathon.UI.ViewModelMappers.Booking
{
    public class GetPendingForVehicleViewModelMapper : IGetPendingForVehicleViewModelMapper
    {
        public IBookingRepository _bookingRepository;

        public GetPendingForVehicleViewModelMapper(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public IList<GetPendingForVehicleViewModel> Map(Guid vehicleId)
        {
            var bookings = _bookingRepository.GetPendingForVehicle(vehicleId);

            var viewModel = bookings.Select(booking => new GetPendingForVehicleViewModel()
                {
                    VehicleId = vehicleId,
                    BookingNumber = booking.BookingNumber,
                    CustomerName = booking.Customer.FamilyName + ", " + booking.Customer.GivenName,
                    StartDate = booking.StartDate.Value,
                    EndDate = booking.EndDate.Value
                }).ToList();

            return viewModel;
        }
    }
}