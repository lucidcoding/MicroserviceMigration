using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Marathon.External.UI.ViewModels.Invoice
{
    public class GenerateViewModel
    {
        [DataType(DataType.Date)]
        [DisplayName("Period From")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? PeriodFrom { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Period To")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? PeriodTo { get; set; }

        [DisplayName("Customer")]
        [Required]
        public Guid? CustomerId { get; set; }

        public SelectList CustomerOptions { get; set; }
    }
}