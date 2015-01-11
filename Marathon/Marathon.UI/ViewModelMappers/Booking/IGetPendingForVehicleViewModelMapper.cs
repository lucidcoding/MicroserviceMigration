using System;
using System.Collections.Generic;
using Marathon.UI.ViewModels.Booking;

namespace Marathon.UI.ViewModelMappers.Booking
{
    public interface IGetPendingForVehicleViewModelMapper
    {
        IList<GetPendingForVehicleViewModel> Map(Guid vehicleId);
    }
}
