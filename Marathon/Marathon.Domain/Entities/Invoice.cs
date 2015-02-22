using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marathon.Domain.Common;
using Marathon.Domain.Requests;
using Marathon.Domain.InfrastructureContracts;

namespace Marathon.Domain.Entities
{
    public class Invoice : Entity<Guid>
    {
        public virtual string InvoiceNumber { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual DateTime PeriodFrom { get; set; }
        public virtual DateTime PeriodTo { get; set; }
        public virtual DateTime InvoiceDate { get; set; }
        public virtual decimal Total { get; set; }

        public static ValidationMessageCollection ValidateGenerate(GenerateInvoiceRequest request)
        {
            var validationMessages = new ValidationMessageCollection();
            return validationMessages;
        }

        public static Invoice Generate(GenerateInvoiceRequest request, IEmailer emailer)
        {
            var invoice = new Invoice();
            var now = DateTime.Now;
            invoice.Id = Guid.NewGuid();
            invoice.CreatedBy = request.GeneratedBy;
            invoice.CreatedOn = now;
            invoice.InvoiceNumber = request.InvoiceNumber;
            invoice.Customer = request.Customer;
            invoice.PeriodFrom = request.PeriodFrom.Value;
            invoice.PeriodTo = request.PeriodTo.Value;
            invoice.InvoiceDate = now;

            var relevantBookings = request
                .Customer
                .Bookings
                .Where(booking =>
                    booking.EndDate >= request.PeriodFrom
                    && booking.EndDate <= request.PeriodTo)
                .ToList();

            invoice.Total = relevantBookings.Sum(booking => booking.Total);
            invoice.SendEmail(emailer);
            return invoice;
        }

        public virtual void SendEmail(IEmailer emailer)
        {
            var subject = string.Format("Invoice for period {0:d MMM yyyy} to {1:d MMM yyyy}", PeriodFrom, PeriodTo);
            var body = new StringBuilder();
            body.AppendLine(string.Format("Dear {0},", Customer.GivenName));
            body.AppendLine();
            body.AppendLine(string.Format("Please pay the outstanding amount of £{0:#.00}", Total));
            body.AppendLine();
            body.AppendLine("Regards,");
            body.AppendLine("The Marathon Team");

            emailer.Send(
                Customer.User.Username,
                "marathon@luciditysoftware.co.uk",
                subject,
                body.ToString());
        }
    }
}
