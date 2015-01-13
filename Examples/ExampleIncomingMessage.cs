using Intis.SDK;
using Intis.SDK.Exceptions;

namespace Examples
{
	class ExampleIncomingMessage
	{
		static void GetIncomingMessage()
		{
            const string login = "your api login";
            const string apiKey = "your api key here";
            const string apiHost = "http://api.host.com/get/";
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
