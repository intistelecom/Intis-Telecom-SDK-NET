using System;
using System.Runtime.Serialization;

namespace Intis.SDK.Entity
{
    [DataContract]
    public class MessageSendingResult
    {
		public Int64 phone { get; set; }

        [DataMember(Name = "id_sms")]
		private string messageId { get; set; }

        [DataMember(Name = "cost")]
        private float cost { get; set; }

        [DataMember(Name = "currency")]
        private string currency { get; set; }

        [DataMember(Name = "count_sms")]
        private int messagesCount { get; set; }

        [DataMember(Name = "error")]
        private string error { get; set; }


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
        /// Price for message
        /// </summary>
        /// <returns>float</returns>
        public float getCost()
        {
            return this.cost;
        }

        /// <summary>
        /// Name of currency
        /// </summary>
        /// <returns>string</returns>
        public string getCurrency()
        {
            return this.currency;
        }

        /// <summary>
        /// Number of message parts
        /// </summary>
        /// <returns>integer</returns>
        public int getMessagesCount()
        {
            return this.messagesCount;
        }

        /// <summary>
        /// Error text in SMS sending
        /// </summary>
        /// <returns>string</returns>
        public string getError()
        {
            return this.error;
        }
    }
}
