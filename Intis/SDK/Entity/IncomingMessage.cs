using System.Runtime.Serialization;

namespace Intis.SDK.Entity
{
    [DataContract]
    public class IncomingMessage
    {
		public string messageId { get; set; }

        [DataMember(Name = "date")]
        private string receivedAt { get; set; }

        [DataMember(Name = "sender")]
        private string originator { get; set; }

        [DataMember(Name = "prefix")]
        private string prefix { get; set; }

        [DataMember(Name = "text")]
        private string text { get; set; }

        /// <summary>
        /// Message ID
        /// </summary>
        /// <returns>string</returns>
        public string getMessageId()
        {
            return this.messageId;
        }

        /// <summary>
        /// Date of message receipt
        /// </summary>
        /// <returns>string</returns>
        public string getReceivedAt()
        {
            return this.receivedAt;
        }

        /// <summary>
        /// Sender name
        /// </summary>
        /// <returns>string</returns>
        public string getOriginator()
        {
            return this.originator;
        }

        /// <summary>
        /// Prefix of incoming message
        /// </summary>
        /// <returns>string</returns>
        public string getPrefix()
        {
            return this.prefix;
        }

        /// <summary>
        /// SMS text
        /// </summary>
        /// <returns>string</returns>
        public string getText()
        {
            return this.text;
        }
    }
}
