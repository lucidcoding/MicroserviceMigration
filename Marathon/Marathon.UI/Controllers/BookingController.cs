using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Marathon.Domain.RepositoryContracts;
using Marathon.UI.ActionFilters;

namespace Marathon.UI.Controllers
{
    public class BookingController : Controller
    {
        private IVehicleRepository _vehicleRepository;

        public BookingController(
            IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        [EntityFrameworkReadContext]
        public ActionResult Make()
        {
            return View();
        }

    }
}
