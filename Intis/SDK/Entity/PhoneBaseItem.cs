// The MIT License (MIT)
// Copyright (c) 2015 Intis Telecom
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Runtime.Serialization;

namespace Intis.SDK.Entity
{
	/// <summary>
	/// Class PhoneBaseItem
	/// Class of getting subscriber data in list
	/// </summary>
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
