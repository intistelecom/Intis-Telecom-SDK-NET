using System;
using Intis.SDK;
using Intis.SDK.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
	[TestClass]
	public class AddToStopListTest
	{
		const string Login = "your api login";
		const string ApiKey = "your api key here";
		const string ApiHost = "http://api.host.com/get/";

		[TestMethod]
		public void TestAddToStopList()
		{

			IApiConnector connector = new LocalApiConnector(getData());

			var client = new IntisClient(Login, ApiKey, ApiHost, connector);

			var id = client.AddToStopList(79009009096);

			Assert.IsNotNull(id);
		}

		[TestMethod]
		[ExpectedException(typeof(AddToStopListException))]
		public void TestAddToStopListException()
		{
			IApiConnector connector = new LocalApiConnector(getErrorData());

			var client = new IntisClient(Login, ApiKey, ApiHost, connector);

			client.AddToStopList(79009009096);
		}

		private string getData()
		{
			return "{\"id\":4}";
		}

		private string getErrorData()
		{
			return "{\"error\":4}";
		}
	}
}
