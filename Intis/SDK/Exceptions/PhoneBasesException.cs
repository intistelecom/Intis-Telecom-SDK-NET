using System;
using System.Collections.Specialized;

namespace Intis.SDK.Exceptions
{
    public class PhoneBasesException : Exception
    {
		public NameValueCollection Parameters { get; set; }

	    public PhoneBasesException(NameValueCollection parameters)
	    {
		    Parameters = parameters;
	    }

	    public PhoneBasesException(NameValueCollection parameters, Exception innerException)
		    : base(innerException.Message)
	    {
			Parameters = parameters;
	    }
    }
}
