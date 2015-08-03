using System;
using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace Intis.SDK.Exceptions
{
    public class AddToStopListException : Exception
    {
        public NameValueCollection Parameters { get; set; }

	    public AddToStopListException(NameValueCollection parameters)
	    {
		    Parameters = parameters;
	    }

		public AddToStopListException(NameValueCollection parameters, Exception innerException)
		    : base(innerException.Message)
	    {
			Parameters = parameters;
	    }
    }
}
