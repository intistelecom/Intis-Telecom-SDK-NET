
namespace Intis.SDK.Entity
{
	public class MessageSendingSuccess : MessageSendingResult
	{
		/// <summary>
		/// Message ID
		/// </summary>
		/// <returns>string</returns>
		public string MessageId { get; set; }

		/// <summary>
		/// Price for message
		/// </summary>
		/// <returns>float</returns>
		public float Cost { get; set; }

		/// <summary>
		/// Name of currency
		/// </summary>
		/// <returns>string</returns>
		public string Currency { get; set; }

		/// <summary>
		/// Number of message parts
		/// </summary>
		/// <returns>integer</returns>
		public int MessagesCount { get; set; }

		public MessageSendingSuccess()
			: base()
		{
			IsOk = true;
		}
	}
}
