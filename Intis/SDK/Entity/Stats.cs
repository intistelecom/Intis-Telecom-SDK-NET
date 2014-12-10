using Newtonsoft.Json.Linq;

namespace Intis.SDK.Entity
{
    public class Stats
    {
        private string state {get; set;}
        private float cost { get; set; }
        private string currency { get; set; }
        private int count { get; set; }

		public Stats(JProperty obj)
        {
		    this.state = obj.Name;
			foreach (var val in obj.Value)
			{
				this.cost = (float)val["cost"];
				this.count = (int)val["parts"];
			}
        }

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
