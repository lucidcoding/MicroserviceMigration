using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Marathon.Domain.InfrastructureContracts;
using Moq;
using Marathon.Domain.Entities;

namespace Marathon.Domain.UnitTests.Entities.BookingTests
{
    [TestClass]
    public class InvoiceTests
    {
        [TestMethod]
        public void CanSendInvoice()
        {
            var emailer = new Mock<IEmailer>();
            string to = null;
            string from = null;
            string subject = null;
            string body = null;

            emailer
                .Setup(x => x.Send(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Callback(delegate(string delegateTo, string delegateFrom, string delegateSubject, string delegateBody)
                    {
                        to = delegateTo;
                        from = delegateFrom;
                        subject = delegateSubject;
                        body = delegateBody;
                    });

            var booking = new Booking()
            {
                Id = Guid.NewGuid(),
                StartMileage = 10000,
                EndMileage = 10100,
                BookingNumber = "Booking001",
                Vehicle = new Vehicle()
                {
                    Id = Guid.NewGuid(),
                    PricePerMile = 0.75m
                },
                Customer = new Customer() 
                {
                    Id = Guid.NewGuid(),
                    GivenName = "Tom",
                    User = new User()
                    {
                        Id = Guid.NewGuid(),
                        Username = "tom.turquoise@luciditysoftware.co.uk"
                    }
                }
            };

            booking.Invoice(emailer.Object);

            Assert.AreEqual("tom.turquoise@luciditysoftware.co.uk", to);
            Assert.AreEqual("marathon@luciditysoftware.co.uk", from);
            Assert.AreEqual("Invoice for Booking Booking001", subject);

            var expectedBody = new StringBuilder();
            expectedBody.AppendLine("Dear Tom,");
            expectedBody.AppendLine();
            expectedBody.AppendLine("Please pay the outstanding amount of £75.00");
            expectedBody.AppendLine();
            expectedBody.AppendLine("Regards,");
            expectedBody.AppendLine("The Marathon Team");

            Assert.AreEqual(expectedBody.ToString(), body);
        }
    }
}
