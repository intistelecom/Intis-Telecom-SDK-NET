using Intis.SDK;
using Intis.SDK.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples
{
	class ExampleDailyStats
	{
		static void GetDailyStats()
		{
			string login = "rso";
			string apiKey = "cfe4fb6f670914b7897cc2783234b7428d6dc826";
			string apiHost = "http://dev.sms16.ru/get/";
			IntisClient client = new IntisClient(login, apiKey, apiHost);

            //List<DailyStats> stats = client.getDailyStatsByMonth(2014, 10);
            //foreach (DailyStats one in stats)
            //{
            //    one.getDay();
            //    var s = one.getStats();
            //    foreach (Stats i in s)
            //    {
            //        var t = i.getCost();
            //        i.getCount();
            //        i.getCurrency();
            //        i.getState();
            //    }
            //}
		}
	}
}
