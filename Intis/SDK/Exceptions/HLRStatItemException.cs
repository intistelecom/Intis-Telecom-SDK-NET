using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace Intis.SDK.Exceptions
{
    class HLRStatItemException : SDKSerializationException
    {
        public HLRStatItemException(NameValueCollection parameters)
            : base(parameters){}

        public HLRStatItemException(NameValueCollection parameters, SerializationException innerException)
            : base(parameters, innerException){}
    }
}
