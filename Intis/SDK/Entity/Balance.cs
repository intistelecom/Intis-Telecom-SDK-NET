using Newtonsoft.Json.Linq;

namespace Intis.SDK.Entity
{
    public class Balance
    {
        private float amount { get; set; }
        private string currency { get; set; }

		public Balance(JToken obj)
		{
			this.amount = (float)obj["money"];
			this.currency = (string)obj["currency"]; 
        }

        /// <summary>
        /// Amount of money
        /// </summary>
        /// <returns>float</returns>
        public float getAmount()
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
