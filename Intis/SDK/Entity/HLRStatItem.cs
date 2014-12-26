using System.Runtime.Serialization;

namespace Intis.SDK.Entity
{
    [DataContract]
    public class HLRStatItem : HLRResponse
    {
        [DataMember(Name = "message_id")]
		private string messageId { get; set; }

        [DataMember(Name = "total_price")]
        private float totalPrice { get; set; }

        [DataMember(Name = "request_id")]
		private string requestId { get; set; }

        [DataMember(Name = "request_time")]
        private string requestTime { get; set; }


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
