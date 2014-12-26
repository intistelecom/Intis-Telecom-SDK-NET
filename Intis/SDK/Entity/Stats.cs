using System.Runtime.Serialization;

namespace Intis.SDK.Entity
{
    [DataContract]
    public class Stats
    {
        public string state {get; set;}

        [DataMember(Name = "cost")]
        private float cost { get; set; }

        [DataMember(Name = "currency")]
        private string currency { get; set; }

        [DataMember(Name = "parts")]
        private int count { get; set; }

        /// <summary>
        /// Status of message
        /// </summary>
        /// <returns>integer</returns>
        public int? getState()
        {
            return MessageState.parse(this.state);
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
        public int getCount()
        {
            return this.count;
        }
    }
}
