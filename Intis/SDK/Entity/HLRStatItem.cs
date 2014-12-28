using System.Runtime.Serialization;

namespace Intis.SDK.Entity
{
    [DataContract]
    public class HlrStatItem : HlrResponse
    {
        /// <summary>
        /// Message ID
        /// </summary>
        /// <returns>string</returns>
        [DataMember(Name = "message_id")]
		public string MessageId { get; set; }

        /// <summary>
        /// Final price
        /// </summary>
        /// <returns>float</returns>
        [DataMember(Name = "total_price")]
        public float TotalPrice { get; set; }

        /// <summary>
        /// Request ID
        /// </summary>
        /// <returns>string</returns>
        [DataMember(Name = "request_id")]
		public string RequestId { get; set; }

        /// <summary>
        /// Time of HLR request
        /// </summary>
        /// <returns>string</returns>
        [DataMember(Name = "request_time")]
        public string RequestTime { get; set; }
    }
}
