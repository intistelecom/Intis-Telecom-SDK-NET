using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Intis.SDK.Entity
{
    public class DailyStats
    {
        private string day{get; set;}
        private List<Stats> stats{get; set;}

        public DailyStats(JToken obj)
        {
		    this.stats = new List<Stats>();
			foreach (var one in obj as JObject)
			{
				this.day = one.Key;
				foreach (var state in one.Value)
				{
					foreach (var val in state)
					{
						this.stats.Add(new Stats(val as JProperty));
					}
					
				}
			}
	    }

        /// <summary>
        /// day for statistics output
        /// </summary>
        /// <returns>string</returns>
        public string getDay()
        {
            return this.day;
        }

        /// <summary>
        /// variable for storing statistics
        /// </summary>
        /// <returns>List Stats</returns>
        public List<Stats> getStats()
        {
            return this.stats;
        }
    }
}
