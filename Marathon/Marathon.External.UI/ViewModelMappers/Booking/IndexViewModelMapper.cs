using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Marathon.Domain.RepositoryContracts;
using Marathon.External.UI.ViewModels.Booking;
using Marathon.External.UI.Security;

namespace Marathon.External.UI.ViewModelMappers.Booking
{
    public class IndexViewModelMapper : IIndexViewModelMapper
    {
        public IUserProvider _userProvider;
        public ICustomerRepository _customerRepository;

        public IndexViewModelMapper(
            IUserProvider userProvider,
            ICustomerRepository customerRepository)
        {
            _userProvider = userProvider;
            _customerRepository = customerRepository;
        }

        public IndexViewModel Map()
        {
            var viewModel = new IndexViewModel();
            var customer = _customerRepository.GetByUsername(_userProvider.GetUsername());
            viewModel.CustomerId = customer.Id.Value;
            viewModel.CustomerName = customer.GivenName + " " + customer.FamilyName;

            viewModel.Bookings = customer.Bookings.Select(booking => new IndexViewModelBooking()
            {
                Id = booking.Id.Value,
                BookingNumber = booking.BookingNumber,
                StartDate = booking.StartDate,
                EndDate = booking.EndDate,
                MakeAndModel = booking.Vehicle.Make + " " + booking.Vehicle.Model,
                Total = booking.Total
            }).ToList();

            return viewModel;
        }
    }
}