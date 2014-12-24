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
        public string title{get; set;}

        [DataMember(Name = "count")]
        public int count{get; set;}

        [DataMember(Name = "pages")]
        public int pages{get; set;}

       
        public BirthdayGreetingSettings birthdayGreetingSettings{get; set;}

        //public PhoneBase(JToken obj)
        //{
        //    this.baseId = Int64.Parse(obj.Path);
        //    this.title = (string)obj.First["name"];
        //    this.count = (int)obj.First["count"];
        //    this.pages = (int)obj.First["pages"];

        //    this.birthdayGreetingSettings = new BirthdayGreetingSettings(obj.First);
        //}

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
