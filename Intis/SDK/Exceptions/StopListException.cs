using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace Intis.SDK.Exceptions
{
    class StopListException : SDKSerializationException
    {
         public StopListException(NameValueCollection parameters)
            : base(parameters){}

         public StopListException(NameValueCollection parameters, SerializationException innerException)
            : base(parameters, innerException){}
    }
}
