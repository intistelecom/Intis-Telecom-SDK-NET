using Intis.SDK;
using Intis.SDK.Exceptions;

namespace Examples
{
	class ExampleDailyStats
	{
		static void GetDailyStats()
		{
            const string login = "your api login";
            const string apiKey = "your api key here";
            const string apiHost = "http://api.host.com/get/";
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
