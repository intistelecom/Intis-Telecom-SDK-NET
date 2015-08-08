// The MIT License (MIT)
// Copyright (c) 2015 Intis Telecom
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System.Runtime.Serialization;

namespace Intis.SDK.Entity
{
	/// <summary>
	/// Class Network
	/// Class for getting operator of subscriber
	/// </summary>
	[DataContract]
	public class Network
	{
		/// <summary>
		/// Operator name
		/// </summary>
		/// <returns>string</returns>
		[DataMember(Name = "operator")]
		public string Title { get; set; }

		/// <summary>
		/// Currency
		/// </summary>
		/// <returns>string</returns>
		[DataMember(Name = "currency")]
		private string Currency { get; set; }

		/// <summary>
		/// Error
		/// </summary>
		/// <returns>string</returns>
		[DataMember(Name = "error")]
		private int Error { get; set; }

		/// <summary>
		/// MCC of subscriber
		/// </summary>
		/// <returns>string</returns>
		[DataMember(Name = "mcc")]
		private string Mcc { get; set; }

		/// <summary>
		/// MNC of subscriber
		/// </summary>
		/// <returns>string</returns>
		[DataMember(Name = "mnc")]
		private string Mnc { get; set; }

		/// <summary>
		/// Phone 
		/// </summary>
		/// <returns>string</returns>
		[DataMember(Name = "phone")]
		private string Phone { get; set; }

		/// <summary>
		/// Ported
		/// </summary>
		/// <returns>string</returns>
		[DataMember(Name = "ported")]
		private string Ported { get; set; }

		/// <summary>
		/// Price
		/// </summary>
		/// <returns>string</returns>
		[DataMember(Name = "price")]
		private string Price { get; set; }

		/// <summary>
		/// Region code
		/// </summary>
		/// <returns>string</returns>
		[DataMember(Name = "regionCode")]
		private int RegionCode { get; set; }

		/// <summary>
		/// Time zone
		/// </summary>
		/// <returns>string</returns>
		[DataMember(Name = "timeZone")]
		private int TimeZone { get; set; }
	}
}
