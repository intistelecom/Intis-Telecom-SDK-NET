using System;
using System.Runtime.Serialization;

namespace Intis.SDK.Entity
{
    [DataContract]
    public class PhoneBaseItem
    {
        /// <summary>
        /// Phone number of subscriber
        /// </summary>
        /// <returns>integer</returns>
		public Int64 Phone { get; set; }

        /// <summary>
        /// Subscriber first name
        /// </summary>
        /// <returns>string</returns>
        [DataMember(Name = "name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Subscriber middle name
        /// </summary>
        /// <returns>string</returns>
        [DataMember(Name = "middle_name")]
        public string MiddleName { get; set; }

        /// <summary>
        /// Subscriber last name
        /// </summary>
        /// <returns>string</returns>
        [DataMember(Name = "last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// Subscriber birth date
        /// </summary>
        /// <returns>string</returns>
        [DataMember(Name = "date_birth")]
        public string BirthDay { get; set; }

        [DataMember(Name = "male")]
        private string GenderString { get; set; }

        /// <summary>
        /// Gender of subscriber
        /// </summary>
        /// <returns>integer</returns>
        public int Gender
        {
            get { return Entity.Gender.Parse(GenderString); }
        }

        /// <summary>
        /// Region of subscriber
        /// </summary>
        /// <returns>string</returns>
        [DataMember(Name = "region")]
        public string Area { get; set; }

        /// <summary>
        /// Operator of subscriber
        /// </summary>
        /// <returns>string</returns>
        [DataMember(Name = "operator")]
        public string Network { get; set; }

        /// <summary>
        /// Note 1
        /// </summary>
        /// <returns>string</returns>
        [DataMember(Name = "note1")]
        public string Note1 { get; set; }

        /// <summary>
        /// Note 2
        /// </summary>
        /// <returns>string</returns>
        [DataMember(Name = "note2")]
        public string Note2 { get; set; }
    }
}
