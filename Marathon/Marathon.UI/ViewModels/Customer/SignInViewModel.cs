using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Marathon.UI.ViewModels.Customer
{
    public class SignInViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [DisplayName("User name:")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Password:")]
        public string Password { get; set; }
    }
}