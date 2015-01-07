using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Marathon.UI.ViewModels.Customer;
using Marathon.Domain.Requests;
using Marathon.UI.ViewModelMappers.Customer;
using Marathon.Domain.Entities;
using Marathon.UI.ActionFilters;

namespace Marathon.UI.Controllers
{
    public class CustomerController : Controller
    {
        private IRegisterViewModelMapper _registerViewModelMapper;

        public CustomerController(
            IRegisterViewModelMapper registerViewModelMapper)
        {
            _registerViewModelMapper = registerViewModelMapper;
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [TransactionScope]
        [EntityFrameworkWriteContext]
        public ActionResult Register(RegisterViewModel viewModel)
        {
            var request = _registerViewModelMapper.Map(viewModel);
            var validationMessages = Customer.ValidateRegister(request);
            validationMessages.ForEach(validationMessage => ModelState.AddModelError(validationMessage.Field, validationMessage.Text));

            if (!ModelState.IsValid)
            {
                //var bus = _busRepository.GetById(inViewModel.BusId);
                //MakeViewModelMapper.Hydrate(inViewModel, bus);
                return View("Register", viewModel);
            }

            //var booking = _bookingService.SummarizeCustomerMake(request);
            //var outViewModel = ReviewViewModelMapper.Map(booking);
            //return View(outViewModel);

            return View();
        }

        public ActionResult SignIn()
        {
            return View();
        }
    }
}
