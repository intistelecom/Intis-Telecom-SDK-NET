using Intis.SDK;
using Intis.SDK.Exceptions;

namespace Examples
{
	class ExampleNetwork
	{
		static void GetNetwork()
		{
			const string login = "rso";
			const string apiKey = "cfe4fb6f670914b7897cc2783234b7428d6dc826";
			const string apiHost = "http://dev.sms16.ru/get/";
			var client = new IntisClient(login, apiKey, apiHost);

            try {
			    var network = client.GetNetworkByPhone(79000000000);
            }
            catch (NetworkException ex)
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
