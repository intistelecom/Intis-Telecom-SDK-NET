using Intis.SDK;
using Intis.SDK.Exceptions;

namespace Examples
{
	class ExampleIncomingMessage
	{
		static void GetIncomingMessage()
		{
			const string login = "rso";
			const string apiKey = "cfe4fb6f670914b7897cc2783234b7428d6dc826";
			const string apiHost = "http://dev.sms16.ru/get/";
			var client = new IntisClient(login, apiKey, apiHost);

            try {
                var messages = client.GetIncomingMessages("2014-10-27");
                foreach (var one in messages)
                {
                    var messageId = one.MessageId;
                    var originator = one.Originator;
                    var prefix = one.Prefix;
                    var receivedAt = one.ReceivedAt;
                    var text = one.Text;
                }
            }
            catch (IncomingMessageException ex)
            {
                var message = ex.Message;
                var parameters = ex.Parameters;
            }
            catch (SdkException ex)
            {
                var message = ex.Message;
                var code = ex.Code;
            }
		}
	}
}
