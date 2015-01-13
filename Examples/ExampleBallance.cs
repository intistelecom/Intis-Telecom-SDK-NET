using Intis.SDK;
using Intis.SDK.Exceptions;

namespace Examples
{
	class ExamplesBallance
	{
		static void GetBallance()
		{
            const string login = "your api login";
            const string apiKey = "your api key here";
            const string apiHost = "http://api.host.com/get/";

			var client = new IntisClient(login, apiKey, apiHost);

            try {
			    var balance = client.GetBalance();
			    var amount = balance.Amount;
			    var currency = balance.Currency;
            }
            catch (BalanceException ex)
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
