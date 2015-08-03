using System;
using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace Intis.SDK.Exceptions
{
    public class StopListException : Exception
    {
		public NameValueCollection Parameters { get; set; }

	    public StopListException(NameValueCollection parameters)
	    {
		    Parameters = parameters;
	    }

		public StopListException(NameValueCollection parameters, Exception innerException)
		    : base(innerException.Message)
	    {
			Parameters = parameters;
	    }
    }
}
