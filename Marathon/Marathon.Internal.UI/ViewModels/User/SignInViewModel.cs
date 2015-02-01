using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Marathon.Internal.UI.ViewModels.User
{
    public class SignInViewModel
    {
        [Required]
        [DisplayName("User name:")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Password:")]
        public string Password { get; set; }
    }
}