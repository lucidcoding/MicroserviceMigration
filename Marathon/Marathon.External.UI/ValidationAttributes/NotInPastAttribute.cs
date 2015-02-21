using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Marathon.External.UI.ValidationAttributes
{
    public class NotInPastAttribute : ValidationAttribute, IClientValidatable
    {
        public override bool IsValid(object value)
        {
            var date = value as DateTime?;

            if (date != null)
            {
                if (date.Value.Date < DateTime.Now.Date)
                {
                    return false;
                }
            }

            return true;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var labelText = metadata.DisplayName ?? metadata.PropertyName;
            yield return new ModelClientValidationRule() { ValidationType = "notinpast", ErrorMessage = "The field " + labelText + " must not be in the past" };
        }
    }
}