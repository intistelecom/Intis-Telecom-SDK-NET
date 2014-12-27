using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace Intis.SDK.Exceptions
{
    class AddTemplateException : SDKSerializationException
    {
        public AddTemplateException(NameValueCollection parameters)
            : base(parameters){}

        public AddTemplateException(NameValueCollection parameters, SerializationException innerException)
            : base(parameters, innerException){}
    }
}
