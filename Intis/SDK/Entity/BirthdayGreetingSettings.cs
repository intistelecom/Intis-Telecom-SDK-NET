
namespace Intis.SDK.Entity
{
	public class BirthdayGreetingSettings
	{
        /// <summary>
        /// key that is responsible for sending birthday greeting
        /// </summary>
        /// <returns>integer</returns>
		public int Enabled { get; set; }

        /// <summary>
        /// number of days to send greetings before
        /// </summary>
        /// <returns>integer</returns>
        public int DaysBefore { get; set; }

        /// <summary>
        /// sender name of greeting SMS
        /// </summary>
        /// <returns>integer</returns>
        public string Originator { get; set; }

        /// <summary>
        /// time for sending greetings
        /// </summary>
        /// <returns>integer</returns>
		public string TimeToSend { get; set; }

        /// <summary>
        /// use local time of subscriber while SMS sending
        /// </summary>
        /// <returns>integer</returns>
        public int UseLocalTime { get; set; }

        /// <summary>
        /// text template for sending greetings
        /// </summary>
        /// <returns>string</returns>
		public string Template { get; set; }

        public BirthdayGreetingSettings(int enabled, int daysBefore, string originator, string timeToSend, int useLocalTime, string template)
        {
            Enabled = enabled;
            DaysBefore = daysBefore;
            Originator = originator;
            TimeToSend = timeToSend;
            UseLocalTime = useLocalTime;
            Template = template;
        }
	}
}
