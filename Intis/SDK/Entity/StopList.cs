using Newtonsoft.Json.Linq;
using System;
using System.Runtime.Serialization;

namespace Intis.SDK.Entity
{
    [DataContract]
    public class StopList
    {
		public Int64 id { get; set; }

        [DataMember(Name = "time_in")]
        private string timeAddedAt { get; set; }

        [DataMember(Name = "description")]
        private string description { get; set; }


        /// <summary>
        /// Stop list ID
        /// </summary>
        /// <returns>integer</returns>
        public Int64 getId()
        {
            return this.id;
        }

        /// <summary>
        /// Time of adding to stop list
        /// </summary>
        /// <returns>string</returns>
        public string getTimeAddedAt()
        {
            return this.timeAddedAt;
        }

        /// <summary>
        /// Reason of adding to stop list
        /// </summary>
        /// <returns>string</returns>
        public string getDescription()
        {
            return this.description;
        }
    }
}
