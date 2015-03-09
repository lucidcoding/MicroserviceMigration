using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Marathon.Domain.Entities;

namespace Marathon.Domain.UnitTests.Entities.CustomerTests
{
    [TestClass]
    public class RegisterTests
    {
        [TestMethod]
        public void CanRegisterCustomer()
        {
            var request = new RegisterCustomerRequestFactory().GetRequest();
            var customer = Customer.Register(request);
            Assert.IsNotNull(customer.Id);
            Assert.AreNotEqual(default(Guid), customer.Id.Value);
            Assert.IsNotNull(customer.User);
            Assert.AreEqual(request.UserId, customer.User.Id);
            Assert.AreEqual(request.EmailAddress, customer.User.Username);
            Assert.AreSame(request.CustomerRole, customer.User.Role);
            Assert.AreSame(request.ApplicationUser, customer.User.CreatedBy);
            Assert.IsNotNull(customer.User.CreatedOn);
            Assert.AreNotEqual(default(DateTime), customer.User.CreatedOn);
            Assert.AreEqual(request.FamilyName, customer.FamilyName);
            Assert.AreEqual(request.GivenName, customer.GivenName);
            Assert.AreEqual(request.Address1, customer.Address1);
            Assert.AreEqual(request.Address2, customer.Address2);
            Assert.AreEqual(request.Address3, customer.Address3);
            Assert.AreEqual(request.Address4, customer.Address4);
            Assert.AreEqual(request.PostCode, customer.PostCode);
            Assert.AreSame(request.ApplicationUser, customer.CreatedBy);
            Assert.IsNotNull(customer.CreatedOn);
            Assert.AreNotEqual(default(DateTime), customer.CreatedOn);
        }
    }
}
