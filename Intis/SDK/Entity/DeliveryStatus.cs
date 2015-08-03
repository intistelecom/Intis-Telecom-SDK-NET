using System.Runtime.Serialization;

namespace Intis.SDK.Entity
{
    [DataContract]
    public class DeliveryStatus
    {
        /// <summary>
        /// Message ID
        /// </summary>
        /// <returns>string</returns>
		[DataMember(Name = "messageId")]
		public string MessageId { get; set; }

        /// <summary>
        /// Status of message
        /// </summary>
        /// <returns>integer</returns>
        [DataMember(Name = "status")]
        public string MessageStatus { get; set; }

        /// <summary>
        /// Time of message
        /// </summary>
        /// <returns>string</returns>
        [DataMember(Name = "time")]
        public string CreatedAt { get; set; }
    }
}
