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
	/// Class OriginatorState
	/// Class for analysis sender status
	/// </summary>
    public static class OriginatorState
    {
        /// <summary>
        /// Constant for approved sender
        /// </summary>
        /// <returns>integer</returns>
        const int Completed = 1;

        /// <summary>
        /// Constant for sender in moderation queue
        /// </summary>
        /// <returns>integer</returns>
        const int Moderation = 2;

        /// <summary>
        /// Constant for rejected sender
        /// </summary>
        /// <returns>integer</returns>
        const int Rejected = 3;

        /// <summary>
        /// Analysis of the string of sender status
        /// </summary>
        /// <param name="str">String presentation of sender status</param>
        /// <returns>integer</returns>
        public static int? Parse(string str)
        {
            switch (str)
            {
                case "completed":
                    return Completed;
                case "order":
                    return Moderation;
                case "rejected":
                    return Rejected;
            }
            return null;
        }
    }
}
