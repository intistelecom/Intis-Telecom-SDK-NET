using System;
using Intis.SDK;
using Intis.SDK.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
	[TestClass]
	public class IncomingMessageTest
	{
		const string Login = "your api login";
		const string ApiKey = "your api key here";
		const string ApiHost = "http://api.host.com/get/";

		[TestMethod]
		public void TestGetIncomingMessages()
		{

			IApiConnector connector = new LocalApiConnector(getData());

			var client = new IntisClient(Login, ApiKey, ApiHost, connector);

			var messages = client.GetIncomingMessages("2014-10-27");
			foreach (var one in messages)
			{
				var messageId = one.MessageId;
				var originator = one.Originator;
				var prefix = one.Prefix;
				var receivedAt = one.ReceivedAt;
				var text = one.Text;
			}

			Assert.IsNotNull(messages);
		}

		[TestMethod]
		[ExpectedException(typeof(IncomingMessageException))]
		public void TestGetIncomingMessagesException()
		{
			IApiConnector connector = new LocalApiConnector(getErrorData());

			var client = new IntisClient(Login, ApiKey, ApiHost, connector);

			client.GetIncomingMessages("2014-10-27");
		}

		private string getData()
		{
			return "{\"75396\":{\"date\":\"2015-04-01 14:01:24\",\"sender\":\"79099004898\",\"prefix\":\"\",\"text\":\"TEST\"},\"75397\":{\"date\":\"2015-04-01 22:31:22\",\"sender\":\"79033145252\",\"prefix\":\"\",\"text\":\"111111111\"},\"75398\":{\"date\":\"2015-04-01 22:37:13\",\"sender\":\"79099004898\",\"prefix\":\"\",\"text\":\"TEST INCOMING\"},\"75399\":{\"date\":\"2015-04-01 22:39:33\",\"sender\":\"79033145252\",\"prefix\":\"\",\"text\":\"2222223\"}}";
		}

		private string getErrorData()
		{
			return "{\"error\":4}";
		}
	}
}
