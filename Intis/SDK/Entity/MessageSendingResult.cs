using Newtonsoft.Json.Linq;
using System;
using System.Numerics;

namespace Intis.SDK.Entity
{
    public class MessageSendingResult
    {
		private Int64 phone { get; set; }
		private BigInteger messageId { get; set; }
        private float cost { get; set; }
        private string currency { get; set; }
        private int messagesCount { get; set; }
        private string error { get; set; }

		public MessageSendingResult(JToken obj)
        {
			var result = obj as JObject;
			foreach (var one in result)
			{
				this.phone = Int64.Parse(one.Key);
				var more = one.Value;
				this.error = (string)more["error"];
				var err = this.getError();
				if (this.getError() == "0") { 
					var id = (string)more["id_sms"];
					this.messageId = BigInteger.Parse(id);
					this.cost = (float)more["cost"];
					this.messagesCount = (int)more["count_sms"];
					this.currency = (string)more["currency"];
				}
			}
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
        /// <returns>integer</returns>
        public BigInteger getMessageId()
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
