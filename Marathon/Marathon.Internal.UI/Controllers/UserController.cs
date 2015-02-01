using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Marathon.Internal.UI.ViewModels.User;
using Marathon.Domain.Requests;
using Marathon.Domain.Entities;
using Marathon.Internal.UI.ActionFilters;
using Marathon.Domain.RepositoryContracts;
using System.Web.Security;

namespace Marathon.Internal.UI.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository _userRepository;

        public UserController(
            IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [AllowAnonymous]
        public ActionResult SignIn()
        {
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

            var user = _userRepository.GetByUsername(viewModel.Username);

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
