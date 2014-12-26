using Intis.SDK;
using Intis.SDK.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples
{
	class ExampleNetwork
	{
		static void GetNetwork()
		{
			string login = "rso";
			string apiKey = "cfe4fb6f670914b7897cc2783234b7428d6dc826";
			string apiHost = "http://dev.sms16.ru/get/";
			IntisClient client = new IntisClient(login, apiKey, apiHost);

			Network network = client.getNetworkByPhone(79000000000);
		}
	}
}
