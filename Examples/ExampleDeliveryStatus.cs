using Intis.SDK;
using Intis.SDK.Exceptions;

namespace Examples
{
	class ExampleDeliveryStatus
	{
		static void GetDeliveryStatus()
		{
            const string login = "your api login";
            const string apiKey = "your api key here";
            const string apiHost = "http://api.host.com/get/";

			var client = new IntisClient(login, apiKey, apiHost);

            try { 
			    var messageId = new [] { "4196226820248326060001" };

                var status = client.GetDeliveryStatus(messageId);
                foreach (var one in status)
                {
                    var meassageId = one.MessageId;
                    var messageStatue = one.MessageStatus;
                    var createdAt = one.CreatedAt;
                }
            }
            catch (DeliveryStatusException ex)
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
