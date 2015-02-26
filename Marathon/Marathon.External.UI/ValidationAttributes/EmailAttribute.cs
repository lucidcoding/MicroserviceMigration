using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Text.RegularExpressions;

namespace Marathon.External.UI.ValidationAttributes
{
    public class EmailAttribute : ValidationAttribute, IClientValidatable
    {
        private const string emailAddressServer = @"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])";
        private const string emailAddressClient = @"[-A-Za-z0-9~!$%^&*_=+}{\'?]+(\.[-A-Za-z0-9~!$%^&*_=+}{\'?]+)*@([A-Za-z0-9_][-A-Za-z0-9_]*(\.[-A-Za-z0-9_]+)*\.([Aa][Ee][Rr][Oo]|[Aa][Rr][Pp][Aa]|[Bb][Ii][Zz]|[Cc][Oo][Mm]|[Cc][Oo]{2}[Pp]|[Ee][Dd][Uu]|[Gg][Oo][Vv]|[Ii][Nn][Ff][Oo]|[Ii][Nn][Tt]|[Mm][Ii][Ll]|[Mm][Uu][Ss][Ee][Uu][Mm]|[Nn][Aa][Mm][Ee]|[Nn][Ee][Tt]|[Oo][Rr][Gg]|[Pp][Rr][Oo]|[Tt][Rr][Aa][Vv][Ee][Ll]|[Mm][Oo][Bb][Ii]|[A-Za-z][A-Za-z])|([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}))(:[0-9]{1,5})?";
        private Regex expressionServer = new Regex(emailAddressServer, RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase);

        public EmailAttribute()
        {
            ErrorMessage = "The field must be a valid email address";
        }

        public override bool IsValid(object value)
        {
            if (value != null && !expressionServer.IsMatch(value.ToString()))
            {
                return false;
            }

            return true;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var labelText = metadata.DisplayName ?? metadata.PropertyName;
            yield return new ModelClientValidationRegexRule("The field " + labelText + " must  be a valid email address", emailAddressClient);
        }
    }
}