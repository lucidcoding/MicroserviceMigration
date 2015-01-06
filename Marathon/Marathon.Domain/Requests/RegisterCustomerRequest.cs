using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marathon.Domain.Entities;

namespace Marathon.Domain.Requests
{
    public class RegisterCustomerRequest
    {
        public virtual User ApplicationUser { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual Role CustomerRole { get; set; }
        public virtual string FamilyName { get; set; }
        public virtual string GivenName { get; set; }
        public virtual string Address1 { get; set; }
        public virtual string Address2 { get; set; }
        public virtual string Address3 { get; set; }
        public virtual string Address4 { get; set; }
        public virtual string PostCode { get; set; }
    }
}
