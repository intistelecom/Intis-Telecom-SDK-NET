using Newtonsoft.Json.Linq;
using System;

namespace Intis.SDK.Entity
{
    public class PhoneBaseItem
    {
		private Int64 phone { get; set; }
        private string firstName { get; set; }
        private string middleName { get; set; }
        private string lastName { get; set; }
        private string birthDay { get; set; }
        private string gender { get; set; }
        private string area { get; set; }
        private string network { get; set; }
        private string note1 { get; set; }
        private string note2 { get; set; }

		public PhoneBaseItem(JToken obj)
        {
			this.phone = Int64.Parse(obj.Path);
			this.firstName = (string)obj.First["name"];
			this.middleName = (string)obj.First["middle_name"];
			this.lastName = (string)obj.First["last_name"];
			this.birthDay = (string)obj.First["date_birth"];
			this.gender = (string)obj.First["male"];
			this.area = (string)obj.First["region"];
			this.network =(string)obj.First["operator"];
			this.note1 = (string)obj.First["note1"];
			this.note2 = (string)obj.First["note2"];
        }

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
