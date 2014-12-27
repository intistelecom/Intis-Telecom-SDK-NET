using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace Intis.SDK.Exceptions
{
    class AddToStopListException : SDKSerializationException
    {
        public AddToStopListException(NameValueCollection parameters)
            : base(parameters){}

        public AddToStopListException(NameValueCollection parameters, SerializationException innerException)
            : base(parameters, innerException){}
    }
}
