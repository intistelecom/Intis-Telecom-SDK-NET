using System.Runtime.Serialization;

namespace Intis.SDK.Entity
{
    [DataContract]
    public class Stats
    {
        public string StateText { get; set; }

        /// <summary>
        /// Status of message
        /// </summary>
        /// <returns>integer</returns>
        public int? State
        {
            get { return MessageState.Parse(StateText); }
        }

        /// <summary>
        /// Price for message
        /// </summary>
        /// <returns>float</returns>
        [DataMember(Name = "cost")]
        public float Cost { get; set; }

        /// <summary>
        /// Name of currency
        /// </summary>
        /// <returns>string</returns>
        [DataMember(Name = "currency")]
        public string Currency { get; set; }

        /// <summary>
        /// Number of message parts
        /// </summary>
        /// <returns>integer</returns>
        [DataMember(Name = "parts")]
        public int Count { get; set; }
    }
}
