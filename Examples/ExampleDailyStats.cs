using Intis.SDK;
using Intis.SDK.Exceptions;

namespace Examples
{
	class ExampleDailyStats
	{
		static void GetDailyStats()
		{
			const string login = "rso";
			const string apiKey = "cfe4fb6f670914b7897cc2783234b7428d6dc826";
			const string apiHost = "http://dev.sms16.ru/get/";
			var client = new IntisClient(login, apiKey, apiHost);

            try { 
                var stats = client.GetDailyStatsByMonth(2014, 10);

                foreach (var one in stats)
                {
                    var day = one.Day;
                    var s = one.Stats;
                    foreach (var i in s)
                    {
                        var cost = i.Cost;
                        var count = i.Count;
                        var currency = i.Currency;
                        var state = i.State;
                    }
                }
            }
            catch (DailyStatsException ex)
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
