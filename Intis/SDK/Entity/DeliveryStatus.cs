using System.Runtime.Serialization;

namespace Intis.SDK.Entity
{
    [DataContract]
    public class DeliveryStatus
    {
		public string messageId { get; set; }

        [DataMember(Name = "status")]
        private string messageStatus { get; set; }

        [DataMember(Name = "time")]
		private string createdAt { get; set;}


        /// <summary>
        /// Message ID
        /// </summary>
        /// <returns>string</returns>
        public string getMessageId()
        {
            return this.messageId;
        }

        /// <summary>
        /// Status of message
        /// </summary>
        /// <returns>integer</returns>
        public int? getMessageStatus()
        {
            return MessageState.parse(this.messageStatus);
        }

        /// <summary>
        /// Time of message
        /// </summary>
        /// <returns>string</returns>
        public string getCreatedAt()
        {
            return this.createdAt;
        }
    }
}
