using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace Intis.SDK.Exceptions
{
    public class PhoneBasesException : SDKSerializationException
    {
         public PhoneBasesException(NameValueCollection parameters)
            : base(parameters){}

         public PhoneBasesException(NameValueCollection parameters, SerializationException innerException)
            : base(parameters, innerException){}
    }
}
