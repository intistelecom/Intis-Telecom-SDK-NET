using System;
using Intis.SDK;
using Intis.SDK.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
	[TestClass]
	public class OriginatorsTest
	{
		const string Login = "your api login";
		const string ApiKey = "your api key here";
		const string ApiHost = "http://api.host.com/get/";

		[TestMethod]
		public void TestGetOriginators()
		{
			IApiConnector connector = new LocalApiConnector(getData());

			var client = new IntisClient(Login, ApiKey, ApiHost, connector);
			var originators = client.GetOriginators();
			foreach (var one in originators)
			{
				var name = one.Name;
				var state = one.State;
			}

			Assert.IsNotNull(originators);
		}

		[TestMethod]
		[ExpectedException(typeof(OriginatorException))]
		public void TestGetOriginatorsException()
		{
			IApiConnector connector = new LocalApiConnector(getErrorData());

			var client = new IntisClient(Login, ApiKey, ApiHost, connector);

			client.GetOriginators();
		}

		private string getData()
		{
			return "{\"smstest\":\"completed\",\"Stok&Sekond\":\"completed\",\"chmvm\":\"completed\",\"rsoTEST\":\"completed\"}";
		}

		private string getErrorData()
		{
			return "{\"error\":4}";
		}
	}
}
