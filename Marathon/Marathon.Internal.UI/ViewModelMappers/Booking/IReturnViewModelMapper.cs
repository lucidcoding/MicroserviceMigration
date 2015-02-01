using System;
using Marathon.Internal.UI.ViewModels.Booking;
using Marathon.Domain.Requests;

namespace Marathon.Internal.UI.ViewModelMappers.Booking
{
    public interface IReturnViewModelMapper
    {
        ReturnViewModel New();
        ReturnBookingRequest Map(ReturnViewModel viewModel);
    }
}
