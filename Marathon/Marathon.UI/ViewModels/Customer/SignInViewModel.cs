using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Marathon.UI.ViewModels.Customer
{
    public class SignInViewModel
    {
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}