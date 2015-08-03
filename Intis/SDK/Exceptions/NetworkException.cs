using System;
using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace Intis.SDK.Exceptions
{
    public class NetworkException : Exception
    {
		public NameValueCollection Parameters { get; set; }

	    public NetworkException(NameValueCollection parameters)
	    {
		    Parameters = parameters;
	    }

		public NetworkException(NameValueCollection parameters, Exception innerException)
		    : base(innerException.Message)
	    {
			Parameters = parameters;
	    }
    }
}
