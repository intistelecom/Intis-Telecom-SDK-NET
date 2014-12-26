using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

namespace Intis.SDK.Entity
{
	public class BirthdayGreetingSettings
	{
		private int enabled { get; set; }
		private int daysBefore { get; set; }
		private string originator { get; set; }
		private string timeToSend { get; set; }
		private int useLocalTime { get; set; }
		private string template { get; set; }

        public BirthdayGreetingSettings(int enabled, int daysBefore, string originator, string timeToSend, int useLocalTime, string template)
        {
            this.enabled = enabled;
            this.daysBefore = daysBefore;
            this.originator = originator;
            this.timeToSend = timeToSend;
            this.useLocalTime = useLocalTime;
            this.template = template;
        }

        /// <summary>
        /// key that is responsible for sending birthday greeting
        /// </summary>
        /// <returns>integer</returns>
        public int getEnebled()
        {
            return this.enabled;
        }

        /// <summary>
        /// number of days to send greetings before
        /// </summary>
        /// <returns>integer</returns>
        public int getDaysBefore()
        {
            return this.daysBefore;
        }

        /// <summary>
        /// sender name of greeting SMS
        /// </summary>
        /// <returns>integer</returns>
        public string getOriginator()
        {
            return this.originator;
        }

        /// <summary>
        /// time for sending greetings
        /// </summary>
        /// <returns>integer</returns>
        public string getTimeToSend()
        {
            return this.timeToSend;
        }

        /// <summary>
        /// use local time of subscriber while SMS sending
        /// </summary>
        /// <returns>integer</returns>
        public int getUselocalTime()
        {
            return this.useLocalTime;
        }

        /// <summary>
        /// text template for sending greetings
        /// </summary>
        /// <returns>string</returns>
        public string getTemplate()
        {
            return this.template;
        }
	}
}
