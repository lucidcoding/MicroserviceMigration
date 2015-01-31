using System;
using Marathon.External.UI.ViewModels.Booking;
using Marathon.Domain.Requests;

namespace Marathon.External.UI.ViewModelMappers.Booking
{
    public interface IReturnViewModelMapper
    {
        ReturnViewModel New();
        ReturnBookingRequest Map(ReturnViewModel viewModel);
    }
}
