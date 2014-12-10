using Newtonsoft.Json.Linq;
using System.Numerics;

namespace Intis.SDK.Entity
{
    public class DeliveryStatus
    {
		private BigInteger messageId { get; set; }
        private string messageStatus { get; set; }

		private string createdAt { get; set;}

		public DeliveryStatus(JToken obj)
        {
			this.messageId = BigInteger.Parse(obj.Path);
			this.messageStatus = (string)obj.First["status"];
			this.createdAt = (string)obj.First["time"];
        }

        /// <summary>
        /// Message ID
        /// </summary>
        /// <returns>integer</returns>
        public BigInteger getMessageId()
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
