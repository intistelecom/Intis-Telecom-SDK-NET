using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace Intis.SDK.Exceptions
{
    public class HlrStatItemException : SdkSerializationException
    {
        public HlrStatItemException(NameValueCollection parameters)
            : base(parameters){}

        public HlrStatItemException(NameValueCollection parameters, SerializationException innerException)
            : base(parameters, innerException){}
    }
}
