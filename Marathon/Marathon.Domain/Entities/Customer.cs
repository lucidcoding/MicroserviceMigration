using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marathon.Domain.Common;
using Marathon.Domain.Requests;
using System.Text.RegularExpressions;

namespace Marathon.Domain.Entities
{
    public class Customer : Entity<Guid>
    {
        public virtual User User { get; set; }
        public virtual string FamilyName { get; set; }
        public virtual string GivenName { get; set; }
        public virtual string Address1 { get; set; }
        public virtual string Address2 { get; set; }
        public virtual string Address3 { get; set; }
        public virtual string Address4 { get; set; }
        public virtual string PostCode { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }

        public static ValidationMessageCollection ValidateRegister(RegisterCustomerRequest request)
        {
            var validationMessages = new ValidationMessageCollection();

            //Only a selection of fields validated for demo purposes.

            var rxPostCode =
                new Regex(
                    @"^(([gG][iI][rR] {0,}0[aA]{2})|((([a-pr-uwyzA-PR-UWYZ][a-hk-yA-HK-Y]?[0-9][0-9]?)|(([a-pr-uwyzA-PR-UWYZ][0-9][a-hjkstuwA-HJKSTUW])|([a-pr-uwyzA-PR-UWYZ][a-hk-yA-HK-Y][0-9][abehmnprv-yABEHMNPRV-Y]))) {0,}[0-9][abd-hjlnp-uw-zABD-HJLNP-UW-Z]{2}))$");

            if (string.IsNullOrEmpty(request.PostCode))
            {
                validationMessages.AddError("PostCode", "Post code not supplied");
            }
            else
            {
                if (!rxPostCode.IsMatch(request.PostCode)) validationMessages.AddError("PostCode", "Post code is not valid.");
            }

            if (string.IsNullOrEmpty(request.EmailAddress))
            {
                validationMessages.AddError("EmailAddress", "Email not supplied");
            }
            else if (request.EmailAddress.Length > 50)
            {
                validationMessages.AddError("EmailAddress", "Email must be 50 characters or less.");
            }
            else
            {
                var rxNonStrictEmail = new Regex(@"[A-Za-z0-9\.-_\+]+@[A-Za-z0-9\.-_\+]+");
                if (!rxNonStrictEmail.IsMatch(request.EmailAddress)) validationMessages.AddError("EmailAddress", "Email is not valid.");
            }

            if (request.ApplicationUser == null)
            {
                validationMessages.AddError("ApplicationUser", "ApplicationUser not supplied");
            }

            if (request.CustomerRole == null)
            {
                validationMessages.AddError("CustomerRole", "CustomerRole not supplied");
            }

            return validationMessages;
        }

        public static Customer Register(RegisterCustomerRequest request)
        {
            var customer = new Customer();
            customer.Id = Guid.NewGuid();
            customer.User = new User();
            customer.User.Id = request.UserId;
            customer.User.Username = request.EmailAddress;
            customer.User.Password = request.Password;
            customer.User.Role = request.CustomerRole;
            customer.User.CreatedBy = request.ApplicationUser;
            customer.User.CreatedOn = DateTime.Now;
            customer.User.Deleted = false;
            customer.FamilyName = request.FamilyName;
            customer.GivenName = request.GivenName;
            customer.Address1 = request.Address1;
            customer.Address2 = request.Address2;
            customer.Address3 = request.Address3;
            customer.Address4 = request.Address4;
            customer.PostCode = request.PostCode;
            customer.CreatedBy = request.ApplicationUser;
            customer.CreatedOn = DateTime.Now;
            customer.Deleted = false;
            return customer;
        }
    }
}
