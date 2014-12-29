using Intis.SDK.Exceptions;
using System.Runtime.Serialization;

namespace Intis.SDK.Entity
{
	class MessageSendingError : MessageSendingResult
	{
		/// <summary>
		/// Error text in SMS sending
		/// </summary>
		/// <returns>string</returns>
		public int Code { get; set; }

		public string Message { get { return SdkException.GetMessage(Code); } }

		public MessageSendingError() 
			: base()
		{
			IsOk = false;
		}
	}
}
