using Newtonsoft.Json.Linq;
using System;

namespace Intis.SDK.Entity
{
    public class HLRStatItem : HLRResponse
    {
		private Int64 phone { get; set; }
		private string messageId { get; set; }
        private float totalPrice { get; set; }
		private string requestId { get; set; }
        private string requestTime { get; set; }

        public HLRStatItem(JToken obj) : base(obj)
        {
			this.phone = Int64.Parse((string)obj["destination"]);
			this.messageId = (string)obj["message_id"];
			this.totalPrice = (float)obj["total_price"];
			this.requestId = (string)obj["request_id"];
			this.requestTime = (string)obj["request_time"];
        }

        /// <summary>
        /// Phone number
        /// </summary>
        /// <returns>integer</returns>
        public Int64 getPhone()
        {
            return this.phone;
        }

        /// <summary>
        /// Message ID
        /// </summary>
        /// <returns>string</returns>
        public string getMessageId()
        {
            return this.messageId;
        }

        /// <summary>
        /// Final price
        /// </summary>
        /// <returns>float</returns>
        public float getTotalPrice()
        {
            return this.totalPrice;
        }

        /// <summary>
        /// Request ID
        /// </summary>
        /// <returns>string</returns>
        public string getRequestId()
        {
            return this.requestId;
        }

        /// <summary>
        /// Time of HLR request
        /// </summary>
        /// <returns>string</returns>
        public string getRequestTime()
        {
            return this.requestTime;
        }
    }
}
