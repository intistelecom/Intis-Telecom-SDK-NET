using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Intis.SDK.Entity
{
    [DataContract]
    public class DailyStats
    {
        private string day{get; set;}
        private List<Stats> stats{get; set;}

        public DailyStats(KeyValuePair<string, Dictionary<string, Stats[]>[]> obj)
        {
            day = obj.Key;

            List<Stats> stats = new List<Stats>();
            foreach (var one in obj.Value)
            {
                foreach (var item in one)
                {
                    var st = item.Key;
                    foreach (var stObj in item.Value)
                    {
                        stObj.state = st;
                        stats.Add(stObj);
                    }
                }   
            }
            this.stats = stats;
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
