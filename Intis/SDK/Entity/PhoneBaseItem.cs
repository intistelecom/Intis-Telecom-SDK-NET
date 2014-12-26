using Newtonsoft.Json.Linq;
using System;
using System.Runtime.Serialization;

namespace Intis.SDK.Entity
{
    [DataContract]
    public class PhoneBaseItem
    {
		public Int64 phone { get; set; }

        [DataMember(Name = "name")]
        private string firstName { get; set; }

        [DataMember(Name = "middle_name")]
        private string middleName { get; set; }

        [DataMember(Name = "last_name")]
        private string lastName { get; set; }

        [DataMember(Name = "date_birth")]
        private string birthDay { get; set; }

        [DataMember(Name = "male")]
        private string gender { get; set; }

        [DataMember(Name = "region")]
        private string area { get; set; }

        [DataMember(Name = "operator")]
        private string network { get; set; }

        [DataMember(Name = "note1")]
        private string note1 { get; set; }

        [DataMember(Name = "note2")]
        private string note2 { get; set; }

        /// <summary>
        /// Phone number of subscriber
        /// </summary>
        /// <returns>integer</returns>
        public Int64 getPhone()
        {
            return this.phone;
        }

        /// <summary>
        /// Subscriber first name
        /// </summary>
        /// <returns>string</returns>
        public string getFirstName()
        {
            return this.firstName;
        }

        /// <summary>
        /// Subscriber middle name
        /// </summary>
        /// <returns>string</returns>
        public string getMiddleName()
        {
            return this.middleName;
        }

        /// <summary>
        /// Subscriber last name
        /// </summary>
        /// <returns>string</returns>
        public string getLastName()
        {
            return this.lastName;
        }

        /// <summary>
        /// Subscriber birth date
        /// </summary>
        /// <returns>string</returns>
        public string getBirthDay()
        {
            return this.birthDay;
        }

        /// <summary>
        /// Gender of subscriber
        /// </summary>
        /// <returns>integer</returns>
        public int getGender()
        {
            return Gender.parse(this.gender);
        }

        /// <summary>
        /// Region of subscriber
        /// </summary>
        /// <returns>string</returns>
        public string getArea()
        {
            return this.area;
        }

        /// <summary>
        /// Operator of subscriber
        /// </summary>
        /// <returns>string</returns>
        public string getNetwork()
        {
            return this.network;
        }

        /// <summary>
        /// Note 1
        /// </summary>
        /// <returns>string</returns>
        public string getNote1()
        {
            return this.note1;
        }

        /// <summary>
        /// Note 2
        /// </summary>
        /// <returns>string</returns>
        public string getNote2()
        {
            return this.note2;
        }
    }
}
