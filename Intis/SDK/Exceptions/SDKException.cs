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
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Intis.SDK.Exceptions
{
	[Serializable]
	public class SdkException : Exception
	{
        public int Code { get; private set; }

		public static string GetMessage(int code)
		{
			var messages = new Dictionary<int, string>
			{
				{0, "Service is disabled"},
				{1, "Signature is not specified"},
				{2, "Login is not specified"},
				{3, "Text is not specified"},
				{4, "Phone number is not specified"},
				{5, "Sender is not specified"},
				{6, "Incorrect signature"},
				{7, "Incorrect login"},
				{8, "Incorrect sender name"},
				{9, "Unregistered sender name"},
				{10, "Sender name is not approved"},
				{11, "There are forbidden words in the text"},
				{12, "SMS sending error"},
				{13, "Phone number is in stop-list. SMS sending to this number is blocked"},
				{14, "There are more than 50 numbers in the request"},
				{15, "List is not specified"},
				{16, "Invalid number"},
				{17, "SMS ID are not specified"},
				{18, "Status is not received"},
				{19, "Empty response"},
				{20, "This number is already taken"},
				{21, "No name"},
				{22, "This template is already created"},
				{23, "Month is not specified (format: YYYY-MM)"},
				{24, "Time stamp is not specified"},
				{25, "Error in access to list"},
				{26, "There are no numbers in the list"},
				{27, "There are no valid numbers"},
				{28, "Initial date is not specified"},
				{29, "Final date is not specified"},
				{30, "Wrong or empty date (format: YYYY-MM-DD)"},
				{31, "Unavailable direction"},
				{32, "Low balance"},
				{33, "Wrong phone number"},
				{34, "Phone is in the global stop-list"},
				{35, "Billing failed"}
			};
		

            string message;
			messages.TryGetValue(code, out message);

			return message;
		}

		public SdkException() { }

		public SdkException(int code)
			: base(GetMessage(code)) {
                Code = code;
        }

		public SdkException(string format, params object[] args)
			: base(string.Format(format, args)) { }

		public SdkException(int code, Exception innerException)
			: base(GetMessage(code), innerException) {
                Code = code;
            }

		public SdkException(string format, Exception innerException, params object[] args)
			: base(string.Format(format, args), innerException) { }

		protected SdkException(SerializationInfo info, StreamingContext context)
			: base(info, context) { }
	}
}
