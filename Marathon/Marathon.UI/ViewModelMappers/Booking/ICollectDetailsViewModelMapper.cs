using System;
using Marathon.UI.ViewModels.Booking;

namespace Marathon.UI.ViewModelMappers.Booking
{
    public interface ICollectDetailsViewModelMapper
    {
        CollectDetailsViewModel Map(string bookingNumber);
    }
}
