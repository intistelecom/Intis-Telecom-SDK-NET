using Intis.SDK;
using Intis.SDK.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples
{
	class ExampleSendMessage
	{
		static void SendMessage()
		{
			string login = "rso";
			string apiKey = "cfe4fb6f670914b7897cc2783234b7428d6dc826";
			string apiHost = "http://dev.sms16.ru/get/";

			IntisClient client = new IntisClient(login, apiKey, apiHost);


			Int64[] phones = new Int64[2] { 79000000000, 79000000001 };
			List<MessageSendingResult> status = client.sendMessage(phones, "smstest", "test");
			foreach (MessageSendingResult one in status)
			{
				one.getPhone();
				one.getMessageId();
				one.getMessagesCount();
				one.getCost();
				one.getCurrency();
				one.getError();
			}
		}
	}
}
