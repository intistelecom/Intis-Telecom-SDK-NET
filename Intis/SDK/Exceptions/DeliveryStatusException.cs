using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Intis.SDK.Exceptions
{
    public class DeliveryStatusException : SDKSerializationException
    {
        public DeliveryStatusException(NameValueCollection parameters)
            : base(parameters){}

        public DeliveryStatusException(NameValueCollection parameters, SerializationException innerException)
            : base(parameters, innerException){}
    }
}
