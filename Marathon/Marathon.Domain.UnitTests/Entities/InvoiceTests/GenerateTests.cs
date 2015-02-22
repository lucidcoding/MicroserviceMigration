using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Marathon.Domain.Requests;
using Marathon.Domain.Entities;
using Marathon.Domain.InfrastructureContracts;
using Moq;

namespace Marathon.Domain.UnitTests.Entities.InvoiceTests
{
    [TestClass]
    public class GenerateTests
    {
        [TestMethod]
        public void EmailIsGenerated()
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

            var request = new GenerateInvoiceRequest();
            request.InvoiceNumber = "ABC123";
            request.PeriodFrom = new DateTime(2010, 10, 1);
            request.PeriodTo = new DateTime(2010, 10, 10);

            request.Customer = new Customer()
            {
                Id = Guid.NewGuid(),
                GivenName = "Tom",
                Bookings = new List<Booking>()
                {
                    new Booking()
                    {
                        EndDate = new DateTime(2010, 10, 2),
                        Total = 200m
                    },
                    new Booking()
                    {
                        EndDate = new DateTime(2010, 10, 9),
                        Total = 150m
                    }
                },
                User = new User()
                {
                    Id = Guid.NewGuid(),
                    Username = "tom.turquoise@luciditysoftware.co.uk"
                }
            };

            var invoice = Invoice.Generate(request, emailer.Object);

            Assert.AreEqual("tom.turquoise@luciditysoftware.co.uk", to);
            Assert.AreEqual("marathon@luciditysoftware.co.uk", from);
            Assert.AreEqual("Invoice for period 1 Oct 2010 to 10 Oct 2010", subject);

            var expectedBody = new StringBuilder();
            expectedBody.AppendLine("Dear Tom,");
            expectedBody.AppendLine();
            expectedBody.AppendLine("Please pay the outstanding amount of £350.00");
            expectedBody.AppendLine();
            expectedBody.AppendLine("Regards,");
            expectedBody.AppendLine("The Marathon Team");

            Assert.AreEqual(expectedBody.ToString(), body);
        }
    }
}
