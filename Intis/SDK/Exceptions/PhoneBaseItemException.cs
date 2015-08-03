using System;
using System.Collections.Specialized;

namespace Intis.SDK.Exceptions
{
    public class PhoneBaseItemException : Exception
    {
		public NameValueCollection Parameters { get; set; }

	    public PhoneBaseItemException(NameValueCollection parameters)
	    {
		    Parameters = parameters;
	    }

		public PhoneBaseItemException(NameValueCollection parameters, Exception innerException)
		    : base(innerException.Message)
	    {
			Parameters = parameters;
	    }
    }
}
