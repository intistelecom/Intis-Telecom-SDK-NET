using System;
using System.Collections.Specialized;

namespace Intis.SDK.Exceptions
{
    public class OriginatorException : Exception
    {
        public NameValueCollection Parameters { get; set; }

	    public OriginatorException(NameValueCollection parameters)
	    {
		    Parameters = parameters;
	    }

		public OriginatorException(NameValueCollection parameters, Exception innerException)
		    : base(innerException.Message)
	    {
			Parameters = parameters;
	    }
    }
}
