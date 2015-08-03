using System;
using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace Intis.SDK.Exceptions
{
    public class DailyStatsException : Exception
    {
		public NameValueCollection Parameters { get; set; }

	    public DailyStatsException(NameValueCollection parameters)
	    {
		    Parameters = parameters;
	    }

		public DailyStatsException(NameValueCollection parameters, Exception innerException)
		    : base(innerException.Message)
	    {
			Parameters = parameters;
	    }
    }
}
