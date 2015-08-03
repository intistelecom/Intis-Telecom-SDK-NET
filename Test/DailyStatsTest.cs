using System;
using Intis.SDK;
using Intis.SDK.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
	[TestClass]
	public class DailyStatsTest
	{
		const string Login = "your api login";
		const string ApiKey = "your api key here";
		const string ApiHost = "http://api.host.com/get/";

		[TestMethod]
		public void TestGetDailyStatsByMonth()
		{
			IApiConnector connector = new LocalApiConnector(getData());

			var client = new IntisClient(Login, ApiKey, ApiHost, connector);

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

			Assert.IsNotNull(stats);
		}

		[TestMethod]
		[ExpectedException(typeof(DailyStatsException))]
		public void TestGetDailyStatsByMonthException()
		{
			IApiConnector connector = new LocalApiConnector(getErrorData());

			var client = new IntisClient(Login, ApiKey, ApiHost, connector);

			client.GetDailyStatsByMonth(2014, 10);
		}

		private string getData()
		{
			return "[{\"date\":\"2014-10-02\",\"stats\":[{\"status\":\"deliver\",\"cost\":\"1.000\",\"parts\":\"2\"},{\"status\":\"not_deliver\",\"cost\":\"0.500\",\"parts\":\"1\"}]}," +
            "{\"date\":\"2014-10-13\",\"stats\":[{\"status\":\"deliver\",\"cost\":\"161.850\",\"parts\":\"358\"},{\"status\":\"expired\",\"cost\":\"1.650\",\"parts\":\"4\"},{\"status\":\"not_deliver\",\"cost\":\"87.700\",\"parts\":\"198\"}]}," +
            "{\"date\":\"2014-10-31\",\"stats\":[{\"status\":\"not_deliver\",\"cost\":\"211.200\",\"parts\":\"459\"},{\"status\":\"deliver\",\"cost\":\"327.950\",\"parts\":\"712\"}]}]";
		}

		private string getErrorData()
		{
			return "{\"error\":4}";
		}
	}
}
