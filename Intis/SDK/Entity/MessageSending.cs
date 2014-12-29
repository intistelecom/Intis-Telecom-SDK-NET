﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Intis.SDK.Entity
{
	[DataContract]
	class MessageSending
	{
		/// <summary>
		/// Phone number
		/// </summary>
		/// <returns>integer</returns>
		public Int64 Phone { get; set; }

		/// <summary>
		/// Message ID
		/// </summary>
		/// <returns>string</returns>
		[DataMember(Name = "id_sms")]
		public string MessageId { get; set; }

		/// <summary>
		/// Price for message
		/// </summary>
		/// <returns>float</returns>
		[DataMember(Name = "cost")]
		public float Cost { get; set; }

		/// <summary>
		/// Name of currency
		/// </summary>
		/// <returns>string</returns>
		[DataMember(Name = "currency")]
		public string Currency { get; set; }

		/// <summary>
		/// Number of message parts
		/// </summary>
		/// <returns>integer</returns>
		[DataMember(Name = "count_sms")]
		public int MessagesCount { get; set; }

		/// <summary>
		/// Error text in SMS sending
		/// </summary>
		/// <returns>string</returns>
		[DataMember(Name = "error")]
		public int Error { get; set; }
	}
}
