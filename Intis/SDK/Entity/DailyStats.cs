using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Intis.SDK.Entity
{
    [DataContract]
    public class DailyStats
    {
        /// <summary>
        /// day for statistics output
        /// </summary>
        /// <returns>string</returns>
        public string Day { get; set; }

        /// <summary>
        /// variable for storing statistics
        /// </summary>
        /// <returns>List Stats</returns>
        public List<Stats> Stats { get; set; }

        public DailyStats(KeyValuePair<string, Dictionary<string, Stats[]>[]> obj)
        {
            Day = obj.Key;

            var stats = new List<Stats>();
            foreach (var one in obj.Value)
            {
                foreach (var item in one)
                {
                    var st = item.Key;
                    foreach (var stObj in item.Value)
                    {
                        stObj.StateText = st;
                        stats.Add(stObj);
                    }
                }   
            }
            Stats = stats;
        }
    }
}
