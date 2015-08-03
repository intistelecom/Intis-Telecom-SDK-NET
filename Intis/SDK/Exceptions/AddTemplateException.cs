using System;
using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace Intis.SDK.Exceptions
{
    public class AddTemplateException : Exception
    {
		public NameValueCollection Parameters { get; set; }

	    public AddTemplateException(NameValueCollection parameters)
	    {
		    Parameters = parameters;
	    }

		public AddTemplateException(NameValueCollection parameters, Exception innerException)
		    : base(innerException.Message)
	    {
			Parameters = parameters;
	    }
    }
}
