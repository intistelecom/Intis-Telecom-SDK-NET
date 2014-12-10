using Newtonsoft.Json.Linq;
using System;

namespace Intis.SDK.Entity
{
    public class StopList
    {
		private Int64 id { get; set; }
        private string timeAddedAt { get; set; }
        private string description { get; set; }

        public StopList(JToken obj)
        {
			foreach (var one in obj)
			{
				this.id = Int64.Parse(one.Path);
				this.timeAddedAt = (string)one.First["time_in"];
				this.description = (string)one.First["description"];
			}
        }

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
