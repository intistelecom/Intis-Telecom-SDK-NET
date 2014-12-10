using Intis.SDK;
using Intis.SDK.Entity;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace Examples
{
    class Program
    {
        static void Main()
        {
            string login = "rso";
            string apiKey = "cfe4fb6f670914b7897cc2783234b7428d6dc826";
            string apiHost = "http://dev.sms16.ru/get/";
            IntisClient client = new IntisClient(login, apiKey, apiHost);

			List<IncomingMessage> messages = client.getIncomingMessages("2014-10-27");
			foreach (IncomingMessage one in messages)
			{
				one.getMessageId();
				one.getOriginator();
				one.getPrefix();
				one.getReceivedAt();
				one.getText();
			}
        }
    }
}
