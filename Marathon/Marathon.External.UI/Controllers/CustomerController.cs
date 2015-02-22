using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Marathon.External.UI.ViewModels.Customer;
using Marathon.Domain.Requests;
using Marathon.External.UI.ViewModelMappers.Customer;
using Marathon.Domain.Entities;
using Marathon.External.UI.ActionFilters;
using Marathon.Domain.RepositoryContracts;
using System.Web.Security;

namespace Marathon.External.UI.Controllers
{
    public class CustomerController : Controller
    {
        private IRegisterViewModelMapper _registerViewModelMapper;
        private ICustomerRepository _customerRepository;
        private IUserRepository _userRepository;

        public CustomerController(
            IRegisterViewModelMapper registerViewModelMapper,
            ICustomerRepository customerRepository,
            IUserRepository userRepository)
        {
            _registerViewModelMapper = registerViewModelMapper;
            _customerRepository = customerRepository;
            _userRepository = userRepository;
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
                return View("Register", viewModel);
            }

            var customer = Customer.Register(request);
            _customerRepository.Save(customer);
            return RedirectToAction("RegisterSuccess");
        }

        public ActionResult RegisterSuccess()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult SignIn(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(SignInViewModel viewModel, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View("SignIn", viewModel);
            }

            var user = _userRepository.GetByUsername(viewModel.EmailAddress);

            if (user == null || !user.Password.Equals(viewModel.Password))
            {
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
                return View("SignIn", viewModel);
            }
            
            FormsAuthentication.SetAuthCookie(user.Username, createPersistentCookie: true);
            return RedirectToLocal(returnUrl);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
