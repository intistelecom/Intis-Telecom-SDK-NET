using System;
using Intis.SDK;
using Intis.SDK.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
	[TestClass]
	public class AddTemplateTest
	{
		const string Login = "your api login";
		const string ApiKey = "your api key here";
		const string ApiHost = "http://api.host.com/get/";

		[TestMethod]
		public void TestAddTemplate()
		{

			IApiConnector connector = new LocalApiConnector(getData());

			var client = new IntisClient(Login, ApiKey, ApiHost, connector);

			var template = client.AddTemplate("test", "this is test");

			Assert.IsNotNull(client);
		}

		[TestMethod]
		[ExpectedException(typeof(AddTemplateException))]
		public void TestAddTemplateException()
		{
			IApiConnector connector = new LocalApiConnector(getErrorData());

			var client = new IntisClient(Login, ApiKey, ApiHost, connector);

			client.AddTemplate("test", "this is test");
		}

		private string getData()
		{
			return "{\"id\":1}";
		}

		private string getErrorData()
		{
			return "{\"error\":4}";
		}
	}
}
