using System;
using Intis.SDK;
using Intis.SDK.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
	[TestClass]
	public class TemplatesTest
	{
		const string Login = "your api login";
		const string ApiKey = "your api key here";
		const string ApiHost = "http://api.host.com/get/";

		[TestMethod]
		public void TestGetTemplates()
		{

			IApiConnector connector = new LocalApiConnector(getData());

			var client = new IntisClient(Login, ApiKey, ApiHost, connector);

			var templates = client.GetTemplates();
			foreach (var one in templates)
			{
				var id = one.Id;
				var title = one.Title;
				var template = one.template;
				var createdAt = one.CreatedAt;
			}

			Assert.IsNotNull(templates);
		}

		[TestMethod]
		[ExpectedException(typeof(TemplateException))]
		public void TestGetTemplatesException()
		{
			IApiConnector connector = new LocalApiConnector(getErrorData());

			var client = new IntisClient(Login, ApiKey, ApiHost, connector);

			client.GetTemplates();
		}

		private string getData()
		{
			return "{\"25583\":{\"name\":\"newtemplate\",\"template\":\"Hello! #first-name# #last-name#! Your amount is #note1#\",\"up_time\":\"2015-03-31 15:22:50\"},\"25586\":{\"name\":\"test1\",\"template\":\"template for test1\",\"up_time\":\"2015-07-29 15:37:47\"},\"25582\":{\"name\":\"vnb cv\",\"template\":\"test\",\"up_time\":\"2015-03-30 17:34:39\"}}";
		}

		private string getErrorData()
		{
			return "{\"error\":4}";
		}
	}
}
