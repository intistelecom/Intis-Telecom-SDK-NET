using System;
using Intis.SDK;
using Intis.SDK.Entity;
using Intis.SDK.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
	[TestClass]
	public class SendMessageTest
	{
		const string Login = "your api login";
		const string ApiKey = "your api key here";
		const string ApiHost = "http://api.host.com/get/";

		[TestMethod]
		public void TestSendMessage()
		{
			IApiConnector connector = new LocalApiConnector(getData());

			var client = new IntisClient(Login, ApiKey, ApiHost, connector);

			var phones = new[] { 79802002020, 79808009090 };

			var status = client.SendMessage(phones, "smstest", "test").ToArray();
			foreach (var one in status)
			{
				if (one.IsOk)
				{
					var success = (MessageSendingSuccess)one;
					var phone = success.Phone;
					var messageId = success.MessageId;
					var messagesCount = success.MessagesCount;
					var cost = success.Cost;
					var currency = success.Currency;
				}
				else
				{
					var error = (MessageSendingError)one;
					var phone = one.Phone;
					var errorCode = error.Code;
					var errorMessage = error.Message;
				}
			}

			Assert.IsNotNull(status);
		}

		[TestMethod]
		[ExpectedException(typeof(MessageSendingResultException))]
		public void TestSendMessageException()
		{
			IApiConnector connector = new LocalApiConnector(getErrorData());

			var client = new IntisClient(Login, ApiKey, ApiHost, connector);

			var phones = new[] { 79802002020, 79808009090 };

			client.SendMessage(phones, "smstest", "test");
		}

		private string getData()
		{
			return "{\"79802002020\":{\"error\":\"0\",\"id_sms\":\"4384607771347164730001\",\"cost\":1,\"count_sms\":1,\"sender\":\"smstest\",\"network\":\" Russia MTC\",\"ported\":0},\"79009009091\":{\"error\":31}}";
		}

		private string getErrorData()
		{
			return "{\"error\":4}";
		}
	}
}
