using System;
using Intis.SDK;
using Intis.SDK.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
	[TestClass]
	public class NetworkTest
	{
		const string Login = "your api login";
		const string ApiKey = "your api key here";
		const string ApiHost = "http://api.host.com/get/";

		[TestMethod]
		public void TestGetNetworkByPhone()
		{

			IApiConnector connector = new LocalApiConnector(getData());

			var client = new IntisClient(Login, ApiKey, ApiHost, connector);

			var network = client.GetNetworkByPhone(79000000000);
			var title = network.Title;

			Assert.IsNotNull(network);
		}

		[TestMethod]
		[ExpectedException(typeof(NetworkException))]
		public void TestGetNetworkByPhoneException()
		{
			IApiConnector connector = new LocalApiConnector(getErrorData());

			var client = new IntisClient(Login, ApiKey, ApiHost, connector);

			client.GetNetworkByPhone(79000000000);
		}

		private string getData()
		{
			return "{\"operator\" : \"AT&T\"}";
		}

		private string getErrorData()
		{
			return "{\"error\":4}";
		}
	}
}
