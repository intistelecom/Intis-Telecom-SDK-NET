using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace Intis.SDK.Exceptions
{
    public class NetworkException:SdkSerializationException
    {
         public NetworkException(NameValueCollection parameters)
            : base(parameters){}

         public NetworkException(NameValueCollection parameters, SerializationException innerException)
            : base(parameters, innerException){}
    }
}
