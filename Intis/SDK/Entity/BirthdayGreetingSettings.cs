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

namespace Intis.SDK.Entity
{
	/// <summary>
	/// Class BirthdayGreetingSettings
	/// Getting settings of birthday greetings
	/// </summary>
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
		/// <returns>string</returns>
        public string Originator { get; set; }

        /// <summary>
        /// time for sending greetings
        /// </summary>
		/// <returns>string</returns>
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
