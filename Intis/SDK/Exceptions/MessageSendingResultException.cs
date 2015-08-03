using System;
using System.Collections.Specialized;

namespace Intis.SDK.Exceptions
{
    public class MessageSendingResultException : Exception
    {
		public NameValueCollection Parameters { get; set; }

	    public MessageSendingResultException(NameValueCollection parameters)
	    {
		    Parameters = parameters;
	    }

		public MessageSendingResultException(NameValueCollection parameters, Exception innerException)
		    : base(innerException.Message)
	    {
			Parameters = parameters;
	    }
    }
}
