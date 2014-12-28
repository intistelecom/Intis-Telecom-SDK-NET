using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace Intis.SDK.Exceptions
{
    public class HlrResponseException : SdkSerializationException
    {
        public HlrResponseException(NameValueCollection parameters)
            : base(parameters){}

        public HlrResponseException(NameValueCollection parameters, SerializationException innerException)
            : base(parameters, innerException){}
    }
}
