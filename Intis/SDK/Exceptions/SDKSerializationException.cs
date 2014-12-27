using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace Intis.SDK.Exceptions
{
    public class SDKSerializationException : SerializationException
    {
        public NameValueCollection Parameters { get; set; }

        public SDKSerializationException()
			: base() { }

        public SDKSerializationException(NameValueCollection parameters)
        {
            this.Parameters = parameters;
        }

        public SDKSerializationException(NameValueCollection parameters, SerializationException innerException)
            : base("Error serialization", innerException)
        {
            this.Parameters = parameters;
        }
    }
}
