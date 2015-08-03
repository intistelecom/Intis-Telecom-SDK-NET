using System;
using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace Intis.SDK.Exceptions
{
    public class HlrResponseException : Exception
    {
		public NameValueCollection Parameters { get; set; }

	    public HlrResponseException(NameValueCollection parameters)
	    {
		    Parameters = parameters;
	    }

		public HlrResponseException(NameValueCollection parameters, Exception innerException)
		    : base(innerException.Message)
	    {
			Parameters = parameters;
	    }
    }
}
