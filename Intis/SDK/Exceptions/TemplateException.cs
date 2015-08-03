using System;
using System.Collections.Specialized;

namespace Intis.SDK.Exceptions
{
    public class TemplateException : Exception
    {
		public NameValueCollection Parameters { get; set; }

	    public TemplateException(NameValueCollection parameters)
	    {
		    Parameters = parameters;
	    }

		public TemplateException(NameValueCollection parameters, Exception innerException)
		    : base(innerException.Message)
	    {
			Parameters = parameters;
	    }
    }
}
