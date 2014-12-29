using Intis.SDK;
using Intis.SDK.Exceptions;

namespace Examples
{
	class ExampleDeliveryStatus
	{
		static void GetDeliveryStatus()
		{
			const string login = "rso";
			const string apiKey = "cfe4fb6f670914b7897cc2783234b7428d6dc826";
			const string apiHost = "http://dev.sms16.ru/get/";

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
