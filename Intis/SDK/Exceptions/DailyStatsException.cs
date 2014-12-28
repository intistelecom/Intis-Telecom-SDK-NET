using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace Intis.SDK.Exceptions
{
    public class DailyStatsException : SdkSerializationException
    {
        public DailyStatsException(NameValueCollection parameters)
            : base(parameters){}

        public DailyStatsException(NameValueCollection parameters, SerializationException innerException)
            : base(parameters, innerException){}
    }
}
