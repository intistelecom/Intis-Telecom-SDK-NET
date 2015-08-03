using System.Runtime.Serialization;

namespace Intis.SDK.Entity
{
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
