using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marathon.Domain.Requests;
using Marathon.Domain.Entities;

namespace Marathon.Domain.UnitTests.Entities.CustomerTests
{
    public class RegisterCustomerRequestFactory
    {
        public RegisterCustomerRequest GetRequest()
        {
            var request = new RegisterCustomerRequest();
            request.UserId = Guid.NewGuid();
            request.ApplicationUser = new User() { Id = Guid.NewGuid() };
            request.CustomerRole = new Role() { Id = Guid.NewGuid() };
            request.EmailAddress = "silvia.silver@silver.com";
            request.FamilyName = "Silver";
            request.GivenName = "Silvia";
            request.Address1 = "1 Silver Lane";
            request.Address2 = "Silverville";
            request.Address3 = "Silvershire";
            request.PostCode = "M1 1AA";
            return request;
        }
    }
}
