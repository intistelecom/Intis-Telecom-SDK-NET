using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace Intis.SDK.Exceptions
{
    class NetworkException:SDKSerializationException
    {
         public NetworkException(NameValueCollection parameters)
            : base(parameters){}

         public NetworkException(NameValueCollection parameters, SerializationException innerException)
            : base(parameters, innerException){}
    }
}
