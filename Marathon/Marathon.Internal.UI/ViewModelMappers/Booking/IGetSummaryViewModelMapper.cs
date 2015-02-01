using System;
using Marathon.Internal.UI.ViewModels.Booking;

namespace Marathon.Internal.UI.ViewModelMappers.Booking
{
    public interface IGetSummaryViewModelMapper
    {
        GetSummaryViewModel Map(string bookingNumber);
    }
}
