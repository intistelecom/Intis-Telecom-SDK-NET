using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Intis.SDK
{
	[Serializable]
	public class SDKException : Exception
	{
	    private static string GetMessage(int code){
			Dictionary<int, string> messages = new Dictionary<int, string>()
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
				{29, "Final date is not specified"}
			};
			string message = "";
			messages.TryGetValue(code, out message);

			return message;
		}

		public SDKException()
			: base() { }

		public SDKException(int code)
			: base(GetMessage(code)) { }

		public SDKException(string format, params object[] args)
			: base(string.Format(format, args)) { }

		public SDKException(int code, Exception innerException)
			: base(GetMessage(code), innerException) { }

		public SDKException(string format, Exception innerException, params object[] args)
			: base(string.Format(format, args), innerException) { }

		protected SDKException(SerializationInfo info, StreamingContext context)
			: base(info, context) { }
	}
}
