﻿using System;
using System.Collections.Specialized;

namespace Intis.SDK.Exceptions
{
    public class BalanceException : Exception
    {
		public NameValueCollection Parameters { get; set; }

	    public BalanceException(NameValueCollection parameters)
	    {
		    Parameters = parameters;
	    }

	    public BalanceException(NameValueCollection parameters, Exception innerException)
		    : base(innerException.Message)
	    {
			Parameters = parameters;
	    }
    }
}
