// The MIT License (MIT)
// Copyright (c) 2015 Intis Telecom
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

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
