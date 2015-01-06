using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Marathon.Domain.Requests;
using Marathon.Domain.Entities;

namespace Marathon.Domain.UnitTests.Entities.CustomerTests
{
    [TestClass]
    public class ValidateRegisterTests
    {
        [TestMethod]
        public void ValidRequestPasses()
        {
            var request = new RegisterCustomerRequestFactory().GetRequest();
            var validationMessages = Customer.ValidateRegister(request);
            Assert.AreEqual(0, validationMessages.Count);
        }

        [TestMethod]
        public void InvalidRequestFails()
        {
            var request = new RegisterCustomerRequest();
            var validationMessages = Customer.ValidateRegister(request);
            Assert.AreEqual(3, validationMessages.Count);
            Assert.IsTrue(validationMessages.Any(x => x.Text.Equals("ApplicationUser not supplied")));
            Assert.IsTrue(validationMessages.Any(x => x.Text.Equals("CustomerRole not supplied")));
            Assert.IsTrue(validationMessages.Any(x => x.Text.Equals("EmailAddress not supplied")));
        }
    }
}
