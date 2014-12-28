using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace Intis.SDK.Exceptions
{
    public class SdkSerializationException : SerializationException
    {
        public NameValueCollection Parameters { get; set; }

        public SdkSerializationException(){ }

        public SdkSerializationException(NameValueCollection parameters)
        {
            Parameters = parameters;
        }

        public SdkSerializationException(NameValueCollection parameters, SerializationException innerException)
            : base("Error serialization", innerException)
        {
            Parameters = parameters;
        }
    }
}
