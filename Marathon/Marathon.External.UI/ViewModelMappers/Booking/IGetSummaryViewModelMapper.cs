using System;
using Marathon.External.UI.ViewModels.Booking;

namespace Marathon.External.UI.ViewModelMappers.Booking
{
    public interface IGetSummaryViewModelMapper
    {
        GetSummaryViewModel Map(string bookingNumber);
    }
}
