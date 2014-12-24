using Intis.SDK;
using Intis.SDK.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples
{
	class ExampleHLRStatItem
	{
		static void GetHLRStatItem()
		{
			string login = "rso";
			string apiKey = "cfe4fb6f670914b7897cc2783234b7428d6dc826";
			string apiHost = "http://dev.sms16.ru/get/";
			IntisClient client = new IntisClient(login, apiKey, apiHost);

            //List<HLRStatItem> HLRStatItem = client.getHlrStats("2014-07-01", "2014-10-01");
            //foreach (HLRStatItem one in HLRStatItem)
            //{
            //    one.getMessageId();
            //    one.getPhone();
            //    one.getRequestId();
            //    one.getRequestTime();
            //    one.getTotalPrice();

            //    one.getId();
            //    one.getIMSI();
            //    one.getDestination();
            //    one.getMCC();
            //    one.getMNC();
            //    one.getOriginalCountryCode();
            //    one.getOriginalCountryName();
            //    one.getOriginalNetworkName();
            //    one.getOriginalNetworkPrefix();
            //    one.getPortedCountryName();
            //    one.getPortedCountryPrefix();
            //    one.getPortedNetworkName();
            //    one.getPortedNetworkPrefix();
            //    one.getPricePerMessage();
            //    one.getRoamingCountryName();
            //    one.getRoamingCountryPrefix();
            //    one.getRoamingNetworkName();
            //    one.getRoamingNetworkPrefix();
            //    one.getStatus();
            //    one.isPorted();
            //    one.isInRoaming();
            //}
		}
	}
}
