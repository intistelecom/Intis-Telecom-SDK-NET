using Intis.SDK;
using Intis.SDK.Entity;
using System.Collections.Generic;

namespace Examples
{
	class ExampleOriginator
	{
		static void getOriginator()
		{
			string login = "rso";
			string apiKey = "cfe4fb6f670914b7897cc2783234b7428d6dc826";
			string apiHost = "http://dev.sms16.ru/get/";

			IntisClient client = new IntisClient(login, apiKey, apiHost);

            //List<Originator> originators = client.getOriginators();
            //foreach (Originator one in originators)
            //{
            //    one.getOriginator();
            //    one.getState();
            //}
		}
	}
}
