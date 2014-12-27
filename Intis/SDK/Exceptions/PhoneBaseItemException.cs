using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace Intis.SDK.Exceptions
{
    public class PhoneBaseItemException : SDKSerializationException
    {
        public PhoneBaseItemException(NameValueCollection parameters)
            : base(parameters){}

        public PhoneBaseItemException(NameValueCollection parameters, SerializationException innerException)
            : base(parameters, innerException){}
    }
}
