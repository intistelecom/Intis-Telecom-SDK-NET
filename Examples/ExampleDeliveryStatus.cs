using Intis.SDK;
using Intis.SDK.Entity;
using System.Collections.Generic;
using System.Numerics;

namespace Examples
{
	class ExampleDeliveryStatus
	{
		static void GetDeliveryStatus()
		{
			string login = "rso";
			string apiKey = "cfe4fb6f670914b7897cc2783234b7428d6dc826";
			string apiHost = "http://dev.sms16.ru/get/";

			IntisClient client = new IntisClient(login, apiKey, apiHost);

			BigInteger[] messageId = new BigInteger[2] { 2, 4 };

            //List<DeliveryStatus> status = client.getDeliveryStatus(messageId);
            //foreach (DeliveryStatus one in status)
            //{
            //    one.getMessageId();
            //    one.getMessageStatus();
            //    one.getCreatedAt();
            //}
		}
	}
}
