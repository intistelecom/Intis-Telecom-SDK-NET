using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace Intis.SDK.Exceptions
{
    public class MessageSendingResultException : SDKSerializationException
    {
        public MessageSendingResultException(NameValueCollection parameters)
            : base(parameters){}

        public MessageSendingResultException(NameValueCollection parameters, SerializationException innerException)
            : base(parameters, innerException){}
    }
}
