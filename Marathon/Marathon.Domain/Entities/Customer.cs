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
        public virtual string Password { get; set; }
        public virtual string FamilyName { get; set; }
        public virtual string GivenName { get; set; }
        public virtual string Address1 { get; set; }
        public virtual string Address2 { get; set; }
        public virtual string Address3 { get; set; }
        public virtual string Address4 { get; set; }
        public virtual string PostCode { get; set; }

        public static Customer Register(RegisterCustomer request)
        {
            var customer = new Customer();
            customer.User = request.User;
            customer.Password = request.Password;
            customer.FamilyName = request.FamilyName;
            customer.GivenName = request.GivenName;
            customer.Address1 = request.Address1;
            customer.Address2 = request.Address2;
            customer.Address3 = request.Address3;
            customer.Address4 = request.Address4;
            customer.PostCode = request.PostCode;
            return customer;
        }
    }
}
