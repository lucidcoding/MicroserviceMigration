using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marathon.Domain.Entities;

namespace Marathon.Domain.Requests
{
    public class GenerateInvoiceRequest
    {
        public string InvoiceNumber { get; set; }
        public Customer Customer { get; set; }
        public DateTime PeriodFrom { get; set; }
        public DateTime PeriodTo { get; set; }
        public User GeneratedBy { get; set; }
    }
}
