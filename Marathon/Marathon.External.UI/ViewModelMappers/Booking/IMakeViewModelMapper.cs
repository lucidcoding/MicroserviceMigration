using System;
using Marathon.External.UI.ViewModels.Booking;
using Marathon.Domain.Requests;

namespace Marathon.External.UI.ViewModelMappers.Booking
{
    public interface IMakeViewModelMapper
    {
        void Hydrate(MakeViewModel viewModel);
        MakeViewModel New();
        MakeBookingRequest Map(MakeViewModel viewModel);
    }
}
