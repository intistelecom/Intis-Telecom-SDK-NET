using System;
using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace Intis.SDK.Exceptions
{
    public class IncomingMessageException : Exception
    {
		public NameValueCollection Parameters { get; set; }

	    public IncomingMessageException(NameValueCollection parameters)
	    {
		    Parameters = parameters;
	    }

		public IncomingMessageException(NameValueCollection parameters, Exception innerException)
		    : base(innerException.Message)
	    {
			Parameters = parameters;
	    }
    }
}
