using Intis.SDK;
using Intis.SDK.Entity;

namespace Examples
{
	class ExamplesBallance
	{
		static void GetBallance()
		{
			string login = "rso";
			string apiKey = "cfe4fb6f670914b7897cc2783234b7428d6dc826";
			string apiHost = "http://dev.sms16.ru/get/";

			IntisClient client = new IntisClient(login, apiKey, apiHost);

			Balance balance = client.getBalance();
			balance.getAmount();
			balance.getCurrency();
		}
	}
}
