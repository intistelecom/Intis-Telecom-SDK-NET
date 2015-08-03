using Intis.SDK;
using Intis.SDK.Entity;
using Intis.SDK.Exceptions;

namespace Examples
{
	internal class ExampleSendMessage
	{
		private static void SendMessage()
		{
			const string login = "your api login";
			const string apiKey = "your api key here";
			const string apiHost = "http://api.host.com/get/";
			var client = new IntisClient(login, apiKey, apiHost);

			var phones = new[] {79802002020, 79808009090};
			try
			{
				var status = client.SendMessage(phones, "smstest", "test").ToArray();
				foreach (var one in status)
				{
					if (one.IsOk)
					{
						var success = (MessageSendingSuccess) one;
						var phone = success.Phone;
						var messageId = success.MessageId;
						var messagesCount = success.MessagesCount;
						var cost = success.Cost;
						var currency = success.Currency;
					}
					else
					{
						var error = (MessageSendingError) one;
						var phone = one.Phone;
						var errorCode = error.Code;
						var errorMessage = error.Message;
					}
				}
			}
			catch (MessageSendingResultException ex)
			{
				var message = ex.Message;
				var code = ex.Parameters;
			}
			catch (SdkException ex)
			{
				var code = ex.Code;
				var message = ex.Message;
			}
		}
	}
}
