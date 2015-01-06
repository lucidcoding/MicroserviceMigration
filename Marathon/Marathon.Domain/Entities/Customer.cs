using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marathon.Domain.Common;
using Marathon.Domain.Requests;

namespace Marathon.Domain.Entities
{
    public class Customer : Entity<Guid>
    {
        public virtual Guid? UserId { get; set; }
        public virtual User User { get; set; }
        public virtual string FamilyName { get; set; }
        public virtual string GivenName { get; set; }
        public virtual string Address1 { get; set; }
        public virtual string Address2 { get; set; }
        public virtual string Address3 { get; set; }
        public virtual string Address4 { get; set; }
        public virtual string PostCode { get; set; }

        public static ValidationMessageCollection ValidateRegister(RegisterCustomerRequest request)
        {
            var validationMessages = new ValidationMessageCollection();

            //Only a selection of fields validated for demo purposes.

            if (request.ApplicationUser == null)
            {
                validationMessages.AddError("ApplicationUser", "ApplicationUser not supplied");
            }

            if (request.CustomerRole == null)
            {
                validationMessages.AddError("CustomerRole", "CustomerRole not supplied");
            }

            if (string.IsNullOrEmpty(request.EmailAddress))
            {
                validationMessages.AddError("EmailAddress", "EmailAddress not supplied");
            }

            return validationMessages;
        }

        public static Customer Register(RegisterCustomerRequest request)
        {
            var customer = new Customer();
            customer.Id = Guid.NewGuid();
            customer.User = new User();
            customer.User.Id = Guid.NewGuid();
            customer.User.Username = request.EmailAddress;
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
