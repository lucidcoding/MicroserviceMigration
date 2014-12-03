using System.Collections.Generic;
using System.Linq;

namespace Marathon.Domain.Common
{
    public class ValidationMessageCollection : List<ValidationMessage>
    {
        public void AddError(string text)
        {
            Add(new ValidationMessage(ValidationMessageType.Error, text));
        }

        public void AddError(string field, string text)
        {
            Add(new ValidationMessage(ValidationMessageType.Error, field, text));
        }

        public void AddWarning(string text)
        {
            Add(new ValidationMessage(ValidationMessageType.Warning, text));
        }

        public List<ValidationMessage> Infos
        {
            get
            {
                return (from validationMessage
                        in this
                        where validationMessage.Type == ValidationMessageType.Info
                        select validationMessage).ToList();
            }
        }

        public List<ValidationMessage> Errors
        {
            get
            {
                return (from validationMessage
                        in this
                        where validationMessage.Type == ValidationMessageType.Error
                        select validationMessage).ToList();
            }
        }

        public List<ValidationMessage> Warnings
        {
            get
            {
                return (from validationMessage
                        in this
                        where validationMessage.Type == ValidationMessageType.Warning
                        select validationMessage).ToList();
            }
        }

        public bool ContainsError(string field, string text)
        {
            return this.Contains(new ValidationMessage(ValidationMessageType.Error, field, text));
        }
    }
}
