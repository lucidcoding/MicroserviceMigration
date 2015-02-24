using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Marathon.Domain.Enumerations
{
    public enum VehicleStatus
    {
        Decommissioned = 0,
        InDepot = 1,
        OutOnBooking = 2,
        UndergoingMaintenance = 3,
    }
}
