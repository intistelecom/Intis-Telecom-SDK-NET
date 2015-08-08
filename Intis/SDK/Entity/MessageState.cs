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
	/// Class MessageState
	/// Class of analysis of message status
	/// </summary>
    public static class MessageState
    {
        /// <summary>
        /// Constant for scheduled message
        /// </summary>
        /// <returns>integer</returns>
        const int Scheduled = 0;

        /// <summary>
        /// Constant for message with ENROUT status
        /// </summary>
        /// <returns>integer</returns>
        const int Enroute = 1;

        /// <summary>
        /// Constant for delivered message
        /// </summary>
        /// <returns>integer</returns>
        const int Delivered = 2;

        /// <summary>
        /// Constant for expired message
        /// </summary>
        /// <returns>integer</returns>
        const int Expired = 3;

        /// <summary>
        /// Constant for deleted message
        /// </summary>
        /// <returns>integer</returns>
        const int Deleted = 4;

        /// <summary>
        /// Constant for undelivered message
        /// </summary>
        /// <returns>integer</returns>
        const int Undeliverable = 5;

        /// <summary>
        /// Constant for sent message
        /// </summary>
        /// <returns>integer</returns>
        const int Accepted = 6;

        /// <summary>
        /// Constant for unknown message
        /// </summary>
        /// <returns>integer</returns>
        const int Unknown = 7;

        /// <summary>
        /// Constant for rejected message
        /// </summary>
        /// <returns>integer</returns>
        const int Rejected = 8;

        /// <summary>
        /// Constant for missed message
        /// </summary>
        /// <returns>integer</returns>
        const int Skipped = 9;

        /// <summary>
        /// Analysis of the string of message status
        /// </summary>
        /// <param name="state">String presentation of message status</param>
        /// <returns>integer</returns>
        public static int? Parse(string state)
        {
            switch (state)
            {
                case "deliver":
                    return Delivered;
                case "expired":
                    return Expired;
                case "not_deliver":
                    return Undeliverable;
                case "partly_deliver":
                    return Accepted;
                default:
                    return null;
            }
        }
    }
}
