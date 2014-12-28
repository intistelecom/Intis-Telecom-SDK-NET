using System.Runtime.Serialization;

namespace Intis.SDK.Entity
{
    [DataContract]
    public class Balance
    {
        /// <summary>
        /// Amount of money
        /// </summary>
        /// <returns>float</returns>
        [DataMember(Name = "money")]
        public string Amount { get; set; }

        /// <summary>
        /// Name of currency
        /// </summary>
        /// <returns>string</returns>
        [DataMember(Name = "currency")]
        public string Currency { get; set; }
    }
}
