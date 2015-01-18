using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Marathon.Domain.RepositoryContracts;
using Marathon.UI.ViewModels.Booking;

namespace Marathon.UI.ViewModelMappers.Booking
{
    public class CollectDetailsViewModelMapper : ICollectDetailsViewModelMapper
    {
        private IBookingRepository _bookingRepository;

        public CollectDetailsViewModelMapper(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public CollectDetailsViewModel Map(string bookingNumber)
        {
            var booking = _bookingRepository.GetByBookingNumber(bookingNumber);
            var viewModel = new CollectDetailsViewModel();


            return viewModel;
        }
    }
}