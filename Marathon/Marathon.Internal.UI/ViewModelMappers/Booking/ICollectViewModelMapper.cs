using System;
using Marathon.Internal.UI.ViewModels.Booking;
using Marathon.Domain.Requests;

namespace Marathon.Internal.UI.ViewModelMappers.Booking
{
    public interface ICollectViewModelMapper
    {
        CollectViewModel New();
        CollectBookingRequest Map(CollectViewModel viewModel);
    }
}
