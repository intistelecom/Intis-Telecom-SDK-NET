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
		[DataMember(Name = "date")]
        public string Day { get; set; }

        /// <summary>
        /// variable for storing statistics
        /// </summary>
        /// <returns>List Stats</returns>
		[DataMember(Name = "stats")]
        public List<Stats> Stats { get; set; }
    }
}
