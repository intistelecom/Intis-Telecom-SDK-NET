using Intis.SDK;
using Intis.SDK.Entity;

namespace Examples
{
	class ExampleSendMessage
	{
		static void SendMessage()
		{
			const string login = "rso";
			const string apiKey = "cfe4fb6f670914b7897cc2783234b7428d6dc826";
			const string apiHost = "http://dev.sms16.ru/get/";

			var client = new IntisClient(login, apiKey, apiHost);


            var phones = new [] { 79802503672};
            var status = client.SendMessage(phones, "smstest", "test");
            foreach (var one in status)
            {
				if (one.IsOk)
				{
					//var result = (MessageSendingSuccess) one;
					//var phone = one.Phone;
					//var messageId = one.MessageId;
					//var messagesCount = one.MessagesCount;
					//var cost = one.Cost;
					//var currency = one.Currency;
				}
				else
				{
					//var result = (MessageSendingError)one;
					//var phone = one.Phone;
					//var errorCode = one.Code;
					//var errorMessage = one.Message;
				}
            }
		}
	}
}
