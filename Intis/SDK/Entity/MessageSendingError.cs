using Intis.SDK.Exceptions;


namespace Intis.SDK.Entity
{
	public class MessageSendingError : MessageSendingResult
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
