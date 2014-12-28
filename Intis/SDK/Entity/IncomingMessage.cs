using System.Runtime.Serialization;

namespace Intis.SDK.Entity
{
    [DataContract]
    public class IncomingMessage
    {
        /// <summary>
        /// Message ID
        /// </summary>
        /// <returns>string</returns>
		public string MessageId { get; set; }

        /// <summary>
        /// Date of message receipt
        /// </summary>
        /// <returns>string</returns>
        [DataMember(Name = "date")]
        public string ReceivedAt { get; set; }

        /// <summary>
        /// Sender name
        /// </summary>
        /// <returns>string</returns>
        [DataMember(Name = "sender")]
        public string Originator { get; set; }

        /// <summary>
        /// Prefix of incoming message
        /// </summary>
        /// <returns>string</returns>
        [DataMember(Name = "prefix")]
        public string Prefix { get; set; }

        /// <summary>
        /// SMS text
        /// </summary>
        /// <returns>string</returns>
        [DataMember(Name = "text")]
        public string Text { get; set; }
    }
}
