using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace Intis.SDK.Exceptions
{
    public class TemplateException : SdkSerializationException
    {
        public TemplateException(NameValueCollection parameters)
            : base(parameters){}

        public TemplateException(NameValueCollection parameters, SerializationException innerException)
            : base(parameters, innerException){}
    }
}
