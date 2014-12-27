using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace Intis.SDK.Exceptions
{
    class BalanceException : SDKSerializationException
    {
        public BalanceException(NameValueCollection parameters)
            : base(parameters){}

        public BalanceException(NameValueCollection parameters, SerializationException innerException)
            : base(parameters, innerException){}
    }
}
