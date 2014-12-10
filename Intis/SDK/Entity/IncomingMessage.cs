using Newtonsoft.Json.Linq;
using System.Numerics;

namespace Intis.SDK.Entity
{
    public class IncomingMessage
    {
		private BigInteger messageId { get; set; }
        private string receivedAt { get; set; }
        private string originator { get; set; }
        private string prefix { get; set; }
        private string text { get; set; }

        public IncomingMessage(JToken obj)
        {
		    this.messageId = BigInteger.Parse((string)obj.Path);
			this.receivedAt = (string)obj.First["date"];
			this.originator = (string)obj.First["sender"];
			this.prefix = (string)obj.First["prefix"];
			this.text = (string)obj.First["text"];
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
