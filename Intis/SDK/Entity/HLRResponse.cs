using Newtonsoft.Json.Linq;
using System;

namespace Intis.SDK.Entity
{
	public class HLRResponse
	{
		private string id { get; set; }
		private Int64 destination { get; set; }
		private string status { get; set; }
		private string IMSI { get; set; }
		private string MCC { get; set; }
		private string MNC { get; set; }
		private string originalCountryName { get; set; }
		private string originalCountryCode { get; set; }
		private string originalNetworkName { get; set; }
		private string originalNetworkPrefix { get; set; }
		private string roamingCountryName { get; set; }
		private string roamingCountryPrefix { get; set; }
		private string roamingNetworkName { get; set; }
		private string roamingNetworkPrefix { get; set; }
		private string portedCountryName { get; set; }
		private string portedCountryPrefix { get; set; }
		private string portedNetworkName { get; set; }
		private string portedNetworkPrefix { get; set; }
		private float pricePerMessage { get; set; }
		private bool ported { get; set; }
		private bool inRoaming { get; set; }

		public HLRResponse(JToken obj)
		{
			this.id = (string)obj["id"];
			this.destination = Int64.Parse((string)obj["destination"]);
			this.status = (string)obj["stat"];
			this.IMSI = (string)obj["IMSI"];
			var mccmnc = (string)obj["mccmnc"];
			this.MCC = mccmnc.Substring(0, 3);
			this.MNC = mccmnc.Substring(3);

			this.originalCountryName = (string)obj["ocn"];
			this.originalCountryCode = (string)obj["ocp"];
			this.originalNetworkName = (string)obj["orn"];
			this.originalNetworkPrefix = (string)obj["onp"];

			this.roamingCountryName = (string)obj["rcn"];
			this.roamingCountryPrefix = (string)obj["rcp"];
			this.roamingNetworkName = (string)obj["ron"];
			this.roamingNetworkPrefix = (string)obj["rnp"];

			this.portedCountryName = (string)obj["pcn"];
			this.portedCountryPrefix = (string)obj["pcp"];
			this.portedNetworkName = (string)obj["pon"];
			this.portedNetworkPrefix = (string)obj["pnp"];

			this.pricePerMessage = (float)obj["ppm"];
			this.ported = (bool)obj["is_ported"];
			this.inRoaming = (bool)obj["is_roaming"];
		}

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
            return this.MCC;
        }

        /// <summary>
        /// MNC of subscriber
        /// </summary>
        /// <returns>string</returns>
        public string getMNC()
        {
            return this.MNC;
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
