using System;
using System.Runtime.Serialization;

namespace Intis.SDK.Entity
{
    [DataContract]
	public class HlrResponse
	{
        /// <summary>
        /// Number ID
        /// </summary>
        /// <returns>string</returns>
        [DataMember(Name = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Addressee
        /// </summary>
        /// <returns>integer</returns>
        [DataMember(Name = "destination")]
        public Int64 Destination { get; set; }

        [DataMember(Name = "stat")]
        private string StatusString { get; set; }

        /// <summary>
        /// Status of subscriber
        /// </summary>
        /// <returns>string</returns>
        public int Status {
            get { return HlrResponseState.Parse(StatusString); } 
        }

        /// <summary>
        /// IMSI of subscriber
        /// </summary>
        /// <returns>string</returns>
        [DataMember(Name = "IMSI")]
        public string Imsi { get; set; }

        [DataMember(Name = "mccmnc")]
        private string Mccmnc { get; set; }

        /// <summary>
        /// MCC of subscriber
        /// </summary>
        /// <returns>string</returns>
        public string Mcc
        {
            get { return Mccmnc.Substring(0, 3); }
        }

        /// <summary>
        /// MNC of subscriber
        /// </summary>
        /// <returns>string</returns>
        public string Mnc
        {
            get { return Mccmnc.Substring(3); }
        }

        /// <summary>
        /// The original code of the subscriber's country
        /// </summary>
        /// <returns>string</returns>
        [DataMember(Name = "ocn")]
        public string OriginalCountryName { get; set; }

        /// <summary>
        /// The original code of the subscriber's country
        /// </summary>
        /// <returns>string</returns>
        [DataMember(Name = "ocp")]
        public string OriginalCountryCode { get; set; }

        /// <summary>
        /// The original name of the subscriber's operator
        /// </summary>
        /// <returns>string</returns>
        [DataMember(Name = "orn")]
		public string OriginalNetworkName { get; set; }

        /// <summary>
        /// The original prefix of the subscriber's operator
        /// </summary>
        /// <returns>string</returns>
        [DataMember(Name = "onp")]
		public string OriginalNetworkPrefix { get; set; }

        /// <summary>
        /// Name of country in the subscriber's roaming
        /// </summary>
        /// <returns>string</returns>
        [DataMember(Name = "rcn")]
		public string RoamingCountryName { get; set; }

        /// <summary>
        /// Prefix of country in the subscriber's roaming
        /// </summary>
        /// <returns>string</returns>
        [DataMember(Name = "rcp")]
		public string RoamingCountryPrefix { get; set; }

        /// <summary>
        /// Operator in the subscriber's roaming
        /// </summary>
        /// <returns>string</returns>
        [DataMember(Name = "ron")]
		public string RoamingNetworkName { get; set; }

        /// <summary>
        /// Prefix of operator in the subscriber's roaming
        /// </summary>
        /// <returns>string</returns>
        [DataMember(Name = "rnp")]
		public string RoamingNetworkPrefix { get; set; }

        /// <summary>
        /// Name of country if the phone number of the subscriber is ported
        /// </summary>
        /// <returns>string</returns>
        [DataMember(Name = "pcn")]
		public string PortedCountryName { get; set; }

        /// <summary>
        /// Prefix of country if the phone number of the subscriber is ported
        /// </summary>
        /// <returns>string</returns>
        [DataMember(Name = "pcp")]
		public string PortedCountryPrefix { get; set; }

        /// <summary>
        /// Name of operator if the phone number of the subscriber is ported
        /// </summary>
        /// <returns>string</returns>
        [DataMember(Name = "pon")]
		public string PortedNetworkName { get; set; }

        /// <summary>
        /// Prefix of operator if the phone number of the subscriber is ported
        /// </summary>
        /// <returns>string</returns>
        [DataMember(Name = "pnp")]
        public string PortedNetworkPrefix { get; set; }

        /// <summary>
        /// Price for message
        /// </summary>
        /// <returns>float</returns>
        [DataMember(Name = "ppm")]
		public float PricePerMessage { get; set; }

        /// <summary>
        /// Key that is responsible for identification of a ported number
        /// </summary>
        /// <returns>integer</returns>
        [DataMember(Name = "is_ported")]
		public bool IsPorted { get; set; }

        /// <summary>
        /// Key that is responsible for identification a subscriber in roaming
        /// </summary>
        /// <returns>string</returns>
        [DataMember(Name = "is_roaming")]
		public bool IsInRoaming { get; set; }
	}
}
