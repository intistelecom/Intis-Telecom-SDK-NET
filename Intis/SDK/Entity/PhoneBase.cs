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
    /// Class PhoneBase
    /// Class for getting data of phone number list
    /// </summary>
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
