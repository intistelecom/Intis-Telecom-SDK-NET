using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace Intis.SDK.Exceptions
{
    class HLRResponseException : SDKSerializationException
    {
        public HLRResponseException(NameValueCollection parameters)
            : base(parameters){}

        public HLRResponseException(NameValueCollection parameters, SerializationException innerException)
            : base(parameters, innerException){}
    }
}
