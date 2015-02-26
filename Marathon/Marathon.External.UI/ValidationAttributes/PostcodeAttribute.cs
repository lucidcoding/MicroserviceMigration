using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Text.RegularExpressions;

namespace Marathon.External.UI.ValidationAttributes
{
    public class PostcodeAttribute : ValidationAttribute, IClientValidatable
    {
        private const string postcodeRegEx = @"^[A-Za-z]{1,2}[0-9]{1,2}[A-Za-z]{0,1}\s*(([0-9]{1,2})([A-Za-z]{1,2})?)?$";
        private Regex expression = new Regex(postcodeRegEx, RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase);

        public PostcodeAttribute()
        {
            ErrorMessage = "The field must be a valid UK postcode";
        }

        public override bool IsValid(object value)
        {
            if (value != null && !expression.IsMatch(value.ToString()))
            {
                return false;
            }

            return true;
        }
        
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var labelText = metadata.DisplayName ?? metadata.PropertyName;
            yield return new ModelClientValidationRegexRule("The field " + labelText + " must  be a valid UK postcode", postcodeRegEx);
        }
    }
}