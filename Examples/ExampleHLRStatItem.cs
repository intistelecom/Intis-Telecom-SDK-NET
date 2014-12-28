using Intis.SDK;

namespace Examples
{
	class ExampleHlrStatItem
	{
		static void GetHlrStatItem()
		{
			const string login = "rso";
			const string apiKey = "cfe4fb6f670914b7897cc2783234b7428d6dc826";
			const string apiHost = "http://dev.sms16.ru/get/";
			var client = new IntisClient(login, apiKey, apiHost);

            var hlrStatItem = client.GetHlrStats("2014-07-01", "2014-10-01");
            foreach (var one in hlrStatItem)
            {
                var messageId = one.MessageId;
                var requestId = one.RequestId;
                var requestTime = one.RequestTime;
                var totalPrice = one.TotalPrice;
                var id = one.Id;
                var imsi = one.Imsi;
                var destination = one.Destination;
                var mcc = one.Mcc;
                var mnc = one.Mnc;
                var originalCountryCode = one.OriginalCountryCode;
                var originalCountryName = one.OriginalCountryName;
                var originalNetworkName = one.OriginalNetworkName;
                var originalNetworkPrefix = one.OriginalNetworkPrefix;
                var portedCountryName = one.PortedCountryName;
                var portedCountryPrefix = one.PortedCountryPrefix;
                var portedNetworkName = one.PortedNetworkName;
                var portedNetworkPrefix = one.PortedNetworkPrefix;
                var pricePerMessage = one.PricePerMessage;
                var roamingCountryName = one.RoamingCountryName;
                var roamingCountryPrefix = one.RoamingCountryPrefix;
                var roamingNetworkName = one.RoamingNetworkName;
                var roamingNetworkPrefix = one.RoamingNetworkPrefix;
                var status = one.Status;
                var isPorted = one.IsPorted;
                var isInRoaming = one.IsInRoaming;
            }
		}
	}
}
