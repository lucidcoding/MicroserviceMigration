using System;
using Marathon.UI.ViewModels.Booking;
using Marathon.Domain.Requests;

namespace Marathon.UI.ViewModelMappers.Booking
{
    public interface IMakeViewModelMapper
    {
        void Hydrate(MakeViewModel viewModel);
        MakeViewModel New();
        MakeBookingRequest Map(MakeViewModel viewModel);
    }
}
