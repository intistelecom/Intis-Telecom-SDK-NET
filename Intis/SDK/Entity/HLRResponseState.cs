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
	/// Class HLRResponseState
	/// Class for analysis of status of subscriber by HLR request
	/// </summary>
    public static class HlrResponseState
    {
        /// <summary>
        /// Constant of the successful status
        /// </summary>
        /// <returns>integer</returns>
        const int Success = 1;

        /// <summary>
        /// Constant of the status error
        /// </summary>
        /// <returns>integer</returns>
        const int Failed = 2;

        /// <summary>
        /// Analysis of the string of status by HLR request
        /// </summary>
        /// <param name="str">String representation of status</param>
        /// <returns>integer</returns>
        public static int Parse(string str)
        {
            return str.ToLower() == "delivrd" ? Success : Failed;
        }
    }
}
