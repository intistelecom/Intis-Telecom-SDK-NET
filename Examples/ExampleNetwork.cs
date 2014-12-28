using Intis.SDK;

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

			var network = client.GetNetworkByPhone(79000000000);
		}
	}
}
