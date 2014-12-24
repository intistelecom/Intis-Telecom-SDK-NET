using System.Runtime.Serialization;

namespace Intis.SDK.Entity
{
    [DataContract]
    public class Balance
    {
        [DataMember(Name = "money")]
        public string amount { get; set; }

        [DataMember(Name = "currency")]
        public string currency { get; set; }


        /// <summary>
        /// Amount of money
        /// </summary>
        /// <returns>float</returns>
        public string getAmount()
        {
            return amount;
        }

        /// <summary>
        /// Name of currency
        /// </summary>
        /// <returns>string</returns>
        public string getCurrency()
        {
            return currency;
        }
    }
}
