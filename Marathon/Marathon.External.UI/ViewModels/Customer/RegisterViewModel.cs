using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel;
using Marathon.External.UI.ValidationAttributes;

namespace Marathon.External.UI.ViewModels.Customer
{
    public class RegisterViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email address")]
        [Email]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Enter Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DisplayName("Family Name:")]
        public string FamilyName { get; set; }

        [Required]
        [DisplayName("Given Name")]
        public string GivenName { get; set; }

        [DisplayName("Address Line 1")]
        public string Address1 { get; set; }

        [DisplayName("Address Line 2")]
        public string Address2 { get; set; }

        [DisplayName("Address Line 3")]
        public string Address3 { get; set; }

        [DisplayName("Address Line 4")]
        public string Address4 { get; set; }

        [Required]
        [DisplayName("Postcode")]
        [Postcode]
        public string PostCode { get; set; }
    }
}