using Intis.SDK;
using Intis.SDK.Exceptions;

namespace Examples
{
	class ExampleNetwork
	{
		static void GetNetwork()
		{
            const string login = "your api login";
            const string apiKey = "your api key here";
            const string apiHost = "http://api.host.com/get/";
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
