using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace Intis.SDK.Exceptions
{
    public class HLRStatItemException : SDKSerializationException
    {
        public HLRStatItemException(NameValueCollection parameters)
            : base(parameters){}

        public HLRStatItemException(NameValueCollection parameters, SerializationException innerException)
            : base(parameters, innerException){}
    }
}
