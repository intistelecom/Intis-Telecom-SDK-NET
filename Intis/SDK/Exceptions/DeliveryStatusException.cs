using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace Intis.SDK.Exceptions
{
    public class DeliveryStatusException : SdkSerializationException
    {
        public DeliveryStatusException(NameValueCollection parameters)
            : base(parameters){}

        public DeliveryStatusException(NameValueCollection parameters, SerializationException innerException)
            : base(parameters, innerException){}
    }
}
