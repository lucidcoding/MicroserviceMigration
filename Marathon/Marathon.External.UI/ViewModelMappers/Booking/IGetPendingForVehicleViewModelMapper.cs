using System;
using System.Collections.Generic;
using Marathon.External.UI.ViewModels.Booking;

namespace Marathon.External.UI.ViewModelMappers.Booking
{
    public interface IGetPendingForVehicleViewModelMapper
    {
        IList<GetPendingForVehicleViewModel> Map(Guid vehicleId);
    }
}
