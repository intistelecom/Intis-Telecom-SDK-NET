using System;
using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace Intis.SDK.Exceptions
{
	public class DeliveryStatusException : Exception
	{
		public NameValueCollection Parameters { get; set; }

		public DeliveryStatusException(NameValueCollection parameters)
		{
			Parameters = parameters;
		}

		public DeliveryStatusException(NameValueCollection parameters, Exception innerException)
			: base(innerException.Message)
		{
			Parameters = parameters;
		}
	}
}
