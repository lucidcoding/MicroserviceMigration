using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Marathon.External.UI.ValidationAttributes
{
    public class FutureDateOnlyAttribute : ValidationAttribute, IClientValidatable
    {
        public FutureDateOnlyAttribute()
        {
            //ErrorMessage = "The field '{0}' must not be in the past";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
#warning server side validation here
            return ValidationResult.Success;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            //if (!string.IsNullOrEmpty(this.ErrorMessageString))
            //{
            //    yield return new ModelClientValidationRule() { ValidationType = "notinpast", ErrorMessage = this.ErrorMessageString };
            //}
            //else
            //{
                var labelText = metadata.DisplayName ?? metadata.PropertyName;
                yield return new ModelClientValidationRule() { ValidationType = "notinpast", ErrorMessage = "The field " + labelText + " must not be in the past" };
            //}
        }
    }
}