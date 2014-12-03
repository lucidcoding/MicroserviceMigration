using System.Runtime.Serialization;

namespace Marathon.Domain.Common
{
    public class ValidationMessage
    {
        protected ValidationMessageType _type;
        protected string _field;
        protected string _text;

        public ValidationMessageType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string Field
        {
            get { return _field; }
            set { _field = value; }
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
        
        public ValidationMessage(ValidationMessageType type, string text)
        {
            _type = type;
            _text = text;
        }

        public ValidationMessage(ValidationMessageType type, string field, string text)
        {
            _type = type;
            _field = field;
            _text = text;
        }
    }
}
