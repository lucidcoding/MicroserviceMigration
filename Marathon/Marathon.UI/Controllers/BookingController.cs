using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Marathon.Domain.RepositoryContracts;
using Marathon.UI.ActionFilters;
using Marathon.UI.Security;
using Marathon.UI.ViewModelMappers.Booking;
using Marathon.UI.ViewModels.Booking;
using Marathon.Domain.Entities;

namespace Marathon.UI.Controllers
{
    [Authorize]
    public class BookingController : Controller
    {
        private IMakeViewModelMapper _makeViewModelMapper;
        private IGetPendingForVehicleViewModelMapper _getPendingForVehicleViewModelMapper;
        private ICollectViewModelMapper _collectViewModelMapper;
        private ICollectDetailsViewModelMapper _collectDetailsViewModelMapper;
        private IBookingRepository _bookingRepository;

        public BookingController(
            IMakeViewModelMapper makeViewModelMapper,
            IGetPendingForVehicleViewModelMapper getPendingForVehicleViewModelMapper,
            ICollectViewModelMapper collectViewModelMapper,
            ICollectDetailsViewModelMapper collectDetailsViewModelMapper,
            IBookingRepository bookingRepository)
        {
            _makeViewModelMapper = makeViewModelMapper;
            _getPendingForVehicleViewModelMapper = getPendingForVehicleViewModelMapper;
            _collectViewModelMapper = collectViewModelMapper;
            _collectDetailsViewModelMapper = collectDetailsViewModelMapper;
            _bookingRepository = bookingRepository;
        }

        [EntityFrameworkReadContext]
        [CustomAuthorize("MakeBooking")]
        public ActionResult Make()
        {
            var viewModel = _makeViewModelMapper.New();
            return View(viewModel);
        }

        [EntityFrameworkReadContext]
        [CustomAuthorize("MakeBooking")]
        public PartialViewResult GetPendingForVehicle(Guid vehicleId)
        {
            var viewModel = _getPendingForVehicleViewModelMapper.Map(vehicleId);
            return PartialView("_PendingForVehicle", viewModel);
        }

        [HttpPost]
        [TransactionScope]
        [EntityFrameworkWriteContext]
        [CustomAuthorize("MakeBooking")]
        public ActionResult Make(MakeViewModel viewModel)
        {
            var request = _makeViewModelMapper.Map(viewModel);
            var validationMessages = Booking.ValidateMake(request);
            validationMessages.ForEach(validationMessage => ModelState.AddModelError(validationMessage.Field, validationMessage.Text));

            if (!ModelState.IsValid)
            {
                _makeViewModelMapper.Hydrate(viewModel);
                return View("Make", viewModel);
            }

            var booking = Booking.Make(request);
            _bookingRepository.Save(booking);
            return RedirectToAction("MakeSuccess");
        }
                
        [CustomAuthorize("MakeBooking")]
        public ActionResult MakeSuccess()
        {
            return View();
        }

        [EntityFrameworkReadContext]
        //[CustomAuthorize("CollectBooking")]
        public ActionResult Collect()
        {
            var viewModel = _collectViewModelMapper.New();
            return View(viewModel);
        }

        [EntityFrameworkReadContext]
        //[CustomAuthorize("CollectBooking")]
        public PartialViewResult GetCollectDetails(string bookingNumber)
        {
            var viewModel = _collectDetailsViewModelMapper.Map(bookingNumber);
            return PartialView("_GetCollectDetails", viewModel);
        }
    }
}
