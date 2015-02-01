using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Marathon.Domain.RepositoryContracts;
using Marathon.Internal.UI.ActionFilters;
using Marathon.Internal.UI.Security;
using Marathon.Internal.UI.ViewModelMappers.Booking;
using Marathon.Internal.UI.ViewModels.Booking;
using Marathon.Domain.Entities;

namespace Marathon.Internal.UI.Controllers
{
    [Authorize]
    public class BookingController : Controller
    {
        private ICollectViewModelMapper _collectViewModelMapper;
        private IGetSummaryViewModelMapper _summaryViewModelMapper;
        private IBookingRepository _bookingRepository;

        public BookingController(
            ICollectViewModelMapper collectViewModelMapper,
            IGetSummaryViewModelMapper summaryViewModelMapper,
            IBookingRepository bookingRepository)
        {
            _collectViewModelMapper = collectViewModelMapper;
            _summaryViewModelMapper = summaryViewModelMapper;
            _bookingRepository = bookingRepository;
        }

        [CustomAuthorize("MakeBooking")]
        public ActionResult MakeSuccess()
        {
            return View();
        }

        [EntityFrameworkReadContext]
        //[CustomAuthorize("CollectBooking")]
        public PartialViewResult GetSummary(string bookingNumber)
        {
            var viewModel = _summaryViewModelMapper.Map(bookingNumber);
            return PartialView("_GetSummary", viewModel);
        }

        [EntityFrameworkReadContext]
        //[CustomAuthorize("CollectBooking")]
        public ActionResult Collect()
        {
            var viewModel = _collectViewModelMapper.New();
            return View(viewModel);
        }

        [HttpPost]
        [TransactionScope]
        [EntityFrameworkWriteContext]
        //[CustomAuthorize("CollectBooking")]
        public ActionResult Collect(CollectViewModel viewModel)
        {
            var booking = _bookingRepository.GetByBookingNumber(viewModel.BookingNumber);
            var request = _collectViewModelMapper.Map(viewModel);

            if (booking == null)
            {
                ModelState.AddModelError("BookingNumber", "No booking could be found matching the specified booking number.");
            }
            else
            {
                var validationMessages = booking.ValidateCollect(request);
                validationMessages.ForEach(validationMessage => ModelState.AddModelError(validationMessage.Field, validationMessage.Text));
            }

            if (!ModelState.IsValid)
            {
                //_makeViewModelMapper.Hydrate(viewModel);
                return View("Collect", viewModel);
            }
                
            booking.Collect(request);
            _bookingRepository.Update(booking);
            return RedirectToAction("CollectSuccess");
        }

        [EntityFrameworkReadContext]
        //[CustomAuthorize("CollectBooking")]
        public ActionResult CollectSuccess()
        {
            return View();
        }

        [EntityFrameworkReadContext]
        //[CustomAuthorize("ReturnBooking")]
        public ActionResult Return()
        {
            var viewModel = _collectViewModelMapper.New();
            return View(viewModel);
        }
    }
}
