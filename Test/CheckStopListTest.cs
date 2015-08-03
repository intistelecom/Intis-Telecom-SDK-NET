using System;
using Intis.SDK;
using Intis.SDK.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
	[TestClass]
	public class CheckStopListTest
	{
		const string Login = "your api login";
		const string ApiKey = "your api key here";
		const string ApiHost = "http://api.host.com/get/";

		[TestMethod]
		public void TestCheckStopList()
		{
			IApiConnector connector = new LocalApiConnector(getData());

			var client = new IntisClient(Login, ApiKey, ApiHost, connector);

			var list = client.CheckStopList(79009009090);
			var id = list.Id;
			var timeAddedAt = list.TimeAddedAt;
			var description = list.Description;

			Assert.IsNotNull(list);
		}

		[TestMethod]
		[ExpectedException(typeof(StopListException))]
		public void TestCheckStopListException()
		{
			IApiConnector connector = new LocalApiConnector(getErrorData());

			var client = new IntisClient(Login, ApiKey, ApiHost, connector);

			client.CheckStopList(79009009090);
		}

		private string getData()
		{
			return "{\"4494794\":{\"time_in\":\"2015-07-31 22:55:00\",\"description\":\"test\"}}";
		}

		private string getErrorData()
		{
			return "{\"error\":4}";
		}
	}
}
