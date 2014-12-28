using System;
using System.Runtime.Serialization;

namespace Intis.SDK.Entity
{
    [DataContract]
    public class StopList
    {
        /// <summary>
        /// Stop list ID
        /// </summary>
        /// <returns>integer</returns>
		public Int64 Id { get; set; }

        /// <summary>
        /// Time of adding to stop list
        /// </summary>
        /// <returns>string</returns>
        [DataMember(Name = "time_in")]
        public string TimeAddedAt { get; set; }

        /// <summary>
        /// Reason of adding to stop list
        /// </summary>
        /// <returns>string</returns>
        [DataMember(Name = "description")]
        public string Description { get; set; }
    }
}
