using System;
using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace Intis.SDK.Exceptions
{
    public class HlrStatItemException : Exception
    {
		public NameValueCollection Parameters { get; set; }

	    public HlrStatItemException(NameValueCollection parameters)
	    {
		    Parameters = parameters;
	    }

		public HlrStatItemException(NameValueCollection parameters, Exception innerException)
		    : base(innerException.Message)
	    {
			Parameters = parameters;
	    }
    }
}
