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

using System.Runtime.Serialization;

namespace Intis.SDK.Entity
{
    /// <summary>
    /// Class DeliveryStatus
    /// Class for getting message statuses
    /// </summary>
    [DataContract]
    public class DeliveryStatus
    {
        /// <summary>
        /// Message ID
        /// </summary>
        /// <returns>string</returns>
		public string MessageId { get; set; }

        /// <summary>
        /// Status of message
        /// </summary>
        /// <returns>integer</returns>
        [DataMember(Name = "status")]
        public string MessageStatus { get; set; }

        /// <summary>
        /// Time of message
        /// </summary>
        /// <returns>string</returns>
        [DataMember(Name = "time")]
        public string CreatedAt { get; set; }
    }
}
