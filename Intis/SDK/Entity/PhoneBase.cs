using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Intis.SDK.Entity
{
    
    [DataContract]
    public class PhoneBase
    {
		public Int64 baseId { get; set; }

        [DataMember(Name = "name")]
        private string title { get; set; }

        [DataMember(Name = "count")]
        private int count { get; set; }

        [DataMember(Name = "pages")]
        private int pages { get; set; }




        [DataMember(Name = "on_birth")]
        private int enabled { get; set; }

        [DataMember(Name = "day_before")]
        private int daysBefore { get; set; }

        [DataMember(Name = "birth_sender")]
        private string originator { get; set; }

        [DataMember(Name = "time_birth")]
        private string timeToSend { get; set; }

        [DataMember(Name = "local_time")]
        private int useLocalTime { get; set; }

        [DataMember(Name = "birth_text")]
        private string template { get; set; }

       
        public BirthdayGreetingSettings birthdayGreetingSettings{
            get{
                return new BirthdayGreetingSettings(enabled, daysBefore, originator, timeToSend, useLocalTime, template);
            }
        }

        /// <summary>
        /// List ID
        /// </summary>
        /// <returns>integer</returns>
        public Int64 getBaseId()
        {
            return this.baseId;
        }

        /// <summary>
        /// Name of list
        /// </summary>
        /// <returns>string</returns>
        public string getTitle()
        {
            return this.title;
        }

        /// <summary>
        /// Number of contacts in list
        /// </summary>
        /// <returns>integer</returns>
        public int getCount()
        {
            return this.count;
        }

        /// <summary>
        /// Number of pages in list
        /// </summary>
        /// <returns>integer</returns>
        public int getPages()
        {
            return this.pages;
        }

        /// <summary>
        /// Settings of birthday greeting for the list contacts
        /// </summary>
        /// <returns>BirthdayGreetingSettings</returns>
        public BirthdayGreetingSettings getBirthdayGreetingSettings()
        {
            return this.birthdayGreetingSettings;
        }
    }
}
