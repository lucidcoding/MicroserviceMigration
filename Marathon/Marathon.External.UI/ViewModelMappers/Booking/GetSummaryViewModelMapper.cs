using Marathon.Domain.RepositoryContracts;
using Marathon.External.UI.ViewModels.Booking;

namespace Marathon.External.UI.ViewModelMappers.Booking
{
    public class GetSummaryViewModelMapper : IGetSummaryViewModelMapper
    {
        private IBookingRepository _bookingRepository;

        public GetSummaryViewModelMapper(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public GetSummaryViewModel Map(string bookingNumber)
        {
            var booking = _bookingRepository.GetByBookingNumber(bookingNumber);
            var viewModel = new GetSummaryViewModel();
            viewModel.CustomerName = booking.Customer.GivenName + " " + booking.Customer.FamilyName;
            viewModel.StartDate = booking.StartDate.Value;
            viewModel.EndDate = booking.EndDate.Value;
            return viewModel;
        }
    }
}