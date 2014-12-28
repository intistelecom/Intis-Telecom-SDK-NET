using System;
using System.Runtime.Serialization;

namespace Intis.SDK.Entity
{
    
    [DataContract]
    public class PhoneBase
    {
        /// <summary>
        /// List ID
        /// </summary>
        /// <returns>integer</returns>
		public Int64 BaseId { get; set; }

        /// <summary>
        /// Name of list
        /// </summary>
        /// <returns>string</returns>
        [DataMember(Name = "name")]
        public string Title { get; set; }

        /// <summary>
        /// Number of contacts in list
        /// </summary>
        /// <returns>integer</returns>
        [DataMember(Name = "count")]
        public int Count { get; set; }

        /// <summary>
        /// Number of pages in list
        /// </summary>
        /// <returns>integer</returns>
        [DataMember(Name = "pages")]
        public int Pages { get; set; }

        [DataMember(Name = "on_birth")]
        private int Enabled { get; set; }

        [DataMember(Name = "day_before")]
        private int DaysBefore { get; set; }

        [DataMember(Name = "birth_sender")]
        private string Originator { get; set; }

        [DataMember(Name = "time_birth")]
        private string TimeToSend { get; set; }

        [DataMember(Name = "local_time")]
        private int UseLocalTime { get; set; }

        [DataMember(Name = "birth_text")]
        private string Template { get; set; }

        /// <summary>
        /// Settings of birthday greeting for the list contacts
        /// </summary>
        /// <returns>BirthdayGreetingSettings</returns>
        public BirthdayGreetingSettings BirthdayGreetingSettings{
            get{
                return new BirthdayGreetingSettings(Enabled, DaysBefore, Originator, TimeToSend, UseLocalTime, Template);
            }
        }
    }
}
