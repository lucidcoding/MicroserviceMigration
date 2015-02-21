using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marathon.Domain.Common;
using Marathon.Domain.Requests;

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

        public static Invoice Generate(GenerateInvoiceRequest request)
        {
            var invoice = new Invoice();
            var now = DateTime.Now;
            invoice.Id = Guid.NewGuid();
            invoice.CreatedBy = request.GeneratedBy;
            invoice.CreatedOn = now;
            invoice.InvoiceNumber = request.InvoiceNumber;
            invoice.Customer = request.Customer;
            invoice.PeriodFrom = request.PeriodFrom;
            invoice.PeriodTo = request.PeriodTo;
            invoice.InvoiceDate = now;

            var relevantBookings = request
                .Customer
                .Bookings
                .Where(booking =>
                    booking.EndDate >= request.PeriodFrom
                    && booking.EndDate <= request.PeriodTo)
                .ToList();

            //invoice.Total = relevantBookings.Select(booking => booking.
            return invoice;
        }
    }
}
