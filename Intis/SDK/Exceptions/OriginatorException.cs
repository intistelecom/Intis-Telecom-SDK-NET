using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace Intis.SDK.Exceptions
{
    public class OriginatorException : SDKSerializationException
    {
        public OriginatorException(NameValueCollection parameters)
            : base(parameters){}

        public OriginatorException(NameValueCollection parameters, SerializationException innerException)
            : base(parameters, innerException){}
    }
}
