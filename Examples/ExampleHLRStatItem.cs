using Intis.SDK;
using Intis.SDK.Exceptions;

namespace Examples
{
	class ExampleHlrStatItem
	{
		static void GetHlrStatItem()
		{
            const string login = "your api login";
            const string apiKey = "your api key here";
            const string apiHost = "http://api.host.com/get/";
			var client = new IntisClient(login, apiKey, apiHost);

            try { 
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
            catch (HlrStatItemException ex)
            {
                var message = ex.Message;
                var parameters = ex.Parameters;
            }
            catch (SdkException ex)
            {
                var message = ex.Message;
                var code = ex.Code;
            }
		}
	}
}
