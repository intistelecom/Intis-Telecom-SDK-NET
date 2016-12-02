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
	/// Class IncomingMessage
	/// Class for getting incoming message
	/// </summary>
    [DataContract]
    public class IncomingMessage
    {
        /// <summary>
        /// Message ID
        /// </summary>
        /// <returns>string</returns>
		public string MessageId { get; set; }

        /// <summary>
        /// Date of message receipt
        /// </summary>
        /// <returns>string</returns>
        [DataMember(Name = "date")]
        public string ReceivedAt { get; set; }

        /// <summary>
        /// Sender name
        /// </summary>
        /// <returns>string</returns>
        [DataMember(Name = "sender")]
        public string Originator { get; set; }

        /// <summary>
        /// Prefix of incoming message
        /// </summary>
        /// <returns>string</returns>
        [DataMember(Name = "prefix")]
        public string Prefix { get; set; }

        /// <summary>
        /// SMS text
        /// </summary>
        /// <returns>string</returns>
        [DataMember(Name = "text")]
        public string Text { get; set; }

        /// <summary>
        /// Message destination
        /// </summary>
        /// <returns>string</returns>
        [DataMember(Name = "phone")]
        public string Destination { get; set; }
    }
}
