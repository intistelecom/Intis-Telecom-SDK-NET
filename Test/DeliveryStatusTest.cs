using System;
using Intis.SDK;
using Intis.SDK.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
	[TestClass]
	public class DeliveryStatusTest
	{
		const string Login = "your api login";
		const string ApiKey = "your api key here";
		const string ApiHost = "http://api.host.com/get/";

		[TestMethod]
		public void TestGetDeliveryStatus()
		{
			IApiConnector connector = new LocalApiConnector(getData());

			var client = new IntisClient(Login, ApiKey, ApiHost, connector);
			var messageId = new[] { "4196226820248326060001" };

			var status = client.GetDeliveryStatus(messageId);
			foreach (var one in status)
			{
				var meassageId = one.MessageId;
				var messageStatue = one.MessageStatus;
				var createdAt = one.CreatedAt;
			}

			Assert.IsNotNull(status);
		}

		[TestMethod]
		[ExpectedException(typeof(DeliveryStatusException))]
		public void TestGetDeliveryStatusException()
		{
			IApiConnector connector = new LocalApiConnector(getErrorData());

			var client = new IntisClient(Login, ApiKey, ApiHost, connector);

			var messageId = new[] { "4196226820248326060001" };

			client.GetDeliveryStatus(messageId);
		}

		private string getData()
		{
			return "[{\"messageId\":1, \"status\":\"deliver\", \"time\":\"2014-10-05\"},{\"messageId\":2, \"status\":\"not_deliver\", \"time\":\"2014-10-01\"}]";
		}

		private string getErrorData()
		{
			return "{\"error\":4}";
		}
	}
}
