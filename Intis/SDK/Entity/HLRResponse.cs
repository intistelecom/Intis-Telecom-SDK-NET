using System;
using System.Runtime.Serialization;

namespace Intis.SDK.Entity
{
    [DataContract]
	public class HLRResponse
	{
        [DataMember(Name = "id")]
		private string id { get; set; }

        [DataMember(Name = "destination")]
		private Int64 destination { get; set; }

        [DataMember(Name = "stat")]
		private string status { get; set; }

        [DataMember(Name = "IMSI")]
		private string IMSI { get; set; }

        [DataMember(Name = "mccmnc")]
        private string mccmnc { get; set; }

        [DataMember(Name = "ocn")]
		private string originalCountryName { get; set; }

        [DataMember(Name = "ocp")]
		private string originalCountryCode { get; set; }

        [DataMember(Name = "orn")]
		private string originalNetworkName { get; set; }

        [DataMember(Name = "onp")]
		private string originalNetworkPrefix { get; set; }

        [DataMember(Name = "rcn")]
		private string roamingCountryName { get; set; }

        [DataMember(Name = "rcp")]
		private string roamingCountryPrefix { get; set; }

        [DataMember(Name = "ron")]
		private string roamingNetworkName { get; set; }

        [DataMember(Name = "rnp")]
		private string roamingNetworkPrefix { get; set; }

        [DataMember(Name = "pcn")]
		private string portedCountryName { get; set; }

        [DataMember(Name = "pcp")]
		private string portedCountryPrefix { get; set; }

        [DataMember(Name = "pon")]
		private string portedNetworkName { get; set; }

        [DataMember(Name = "pnp")]
		private string portedNetworkPrefix { get; set; }

        [DataMember(Name = "ppm")]
		private float pricePerMessage { get; set; }

        [DataMember(Name = "is_ported")]
		private bool ported { get; set; }

        [DataMember(Name = "is_roaming")]
		private bool inRoaming { get; set; }

        /// <summary>
        /// Number ID
        /// </summary>
        /// <returns>string</returns>
        public string getId()
        {
            return this.id;
        }

        /// <summary>
        /// Addressee
        /// </summary>
        /// <returns>integer</returns>
        public Int64 getDestination()
        {
            return this.destination;
        }

        /// <summary>
        /// Status of subscriber
        /// </summary>
        /// <returns>string</returns>
        public int getStatus()
        {
            return HLRResponseState.parse(this.status);
        }

        /// <summary>
        /// IMSI of subscriber
        /// </summary>
        /// <returns>string</returns>
        public string getIMSI()
        {
            return this.IMSI;
        }

        /// <summary>
        /// MCC of subscriber
        /// </summary>
        /// <returns>string</returns>
        public string getMCC()
        {
            return mccmnc.Substring(0, 3);
        }

        /// <summary>
        /// MNC of subscriber
        /// </summary>
        /// <returns>string</returns>
        public string getMNC()
        {
            return mccmnc.Substring(3);
        }

        /// <summary>
        /// The original name of the subscriber's country
        /// </summary>
        /// <returns>string</returns>
        public string getOriginalCountryName()
        {
            return this.originalCountryName;
        }

        /// <summary>
        /// The original code of the subscriber's country
        /// </summary>
        /// <returns>string</returns>
        public string getOriginalCountryCode()
        {
            return this.originalCountryCode;
        }

        /// <summary>
        /// The original name of the subscriber's operator
        /// </summary>
        /// <returns>string</returns>
        public string getOriginalNetworkName()
        {
            return this.originalNetworkName;
        }

        /// <summary>
        /// The original prefix of the subscriber's operator
        /// </summary>
        /// <returns>string</returns>
        public string getOriginalNetworkPrefix()
        {
            return this.originalNetworkPrefix;
        }

        /// <summary>
        /// Name of country in the subscriber's roaming
        /// </summary>
        /// <returns>string</returns>
        public string getRoamingCountryName()
        {
            return this.roamingCountryName;
        }

        /// <summary>
        /// Prefix of country in the subscriber's roaming
        /// </summary>
        /// <returns>string</returns>
        public string getRoamingCountryPrefix()
        {
            return this.roamingCountryPrefix;
        }

        /// <summary>
        /// Operator in the subscriber's roaming
        /// </summary>
        /// <returns>string</returns>
        public string getRoamingNetworkName()
        {
            return this.roamingNetworkName;
        }

        /// <summary>
        /// Prefix of operator in the subscriber's roaming
        /// </summary>
        /// <returns>string</returns>
        public string getRoamingNetworkPrefix()
        {
            return this.roamingNetworkPrefix;
        }

        /// <summary>
        /// Name of country if the phone number of the subscriber is ported
        /// </summary>
        /// <returns>string</returns>
        public string getPortedCountryName()
        {
            return this.portedCountryName;
        }

        /// <summary>
        /// Prefix of country if the phone number of the subscriber is ported
        /// </summary>
        /// <returns>string</returns>
        public string getPortedCountryPrefix()
        {
            return this.portedCountryPrefix;
        }

        /// <summary>
        /// Name of operator if the phone number of the subscriber is ported
        /// </summary>
        /// <returns>string</returns>
        public string getPortedNetworkName()
        {
            return this.portedNetworkName;
        }

        /// <summary>
        /// Prefix of operator if the phone number of the subscriber is ported
        /// </summary>
        /// <returns>string</returns>
        public string getPortedNetworkPrefix()
        {
            return this.portedNetworkPrefix;
        }

        /// <summary>
        /// Price for message
        /// </summary>
        /// <returns>float</returns>
        public float getPricePerMessage()
        {
            return this.pricePerMessage;
        }

        /// <summary>
        /// Key that is responsible for identification of a ported number
        /// </summary>
        /// <returns>integer</returns>
        public bool isPorted()
        {
            return this.ported;
        }

        /// <summary>
        /// Key that is responsible for identification a subscriber in roaming
        /// </summary>
        /// <returns>string</returns>
        public bool isInRoaming()
        {
            return this.inRoaming;
        }
	}
}
