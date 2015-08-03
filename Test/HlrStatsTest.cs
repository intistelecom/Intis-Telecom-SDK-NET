using System;
using Intis.SDK;
using Intis.SDK.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
	[TestClass]
	public class HlrStatsTest
	{
		const string Login = "your api login";
		const string ApiKey = "your api key here";
		const string ApiHost = "http://api.host.com/get/";

		[TestMethod]
		public void TestGetHlrStats()
		{
			IApiConnector connector = new LocalApiConnector(getData());

			var client = new IntisClient(Login, ApiKey, ApiHost, connector);

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

			Assert.IsNotNull(hlrStatItem);
		}

		[TestMethod]
		[ExpectedException(typeof(HlrStatItemException))]
		public void TestGetHlrStatsException()
		{
			IApiConnector connector = new LocalApiConnector(getErrorData());

			var client = new IntisClient(Login, ApiKey, ApiHost, connector);

			client.GetHlrStats("2014-07-01", "2014-10-01");
		}

		private string getData()
		{
			return "{\"79178880143\":{\"id\":\"4133004490987800000001\",\"destination\":\"79178880143\",\"message_id\":\"x6ikubibd4y5ljdnttxt\",\"IMSI\":\"250017224827276\",\"stat\":\"DELIVRD\",\"error\":\"0\",\"orn\":\"MTS (Mobile TeleSystems)\",\"pon\":\"MTS (Mobile TeleSystems)\",\"ron\":\"MTS (Mobile TeleSystems)\",\"mccmnc\":\"25001\",\"rcn\":\"Russian Federation\",\"ppm\":\"932\",\"onp\":\"91788\",\"ocn\":\"Russian Federation\",\"ocp\":\"7\",\"is_ported\":\"false\",\"rnp\":\"917\",\"rcp\":\"7\",\"is_roaming\":\"false\",\"pnp\":\"79872500000\",\"pcn\":\"Russian Federation\",\"pcp\":\"7\",\"total_price\":\"0.2\",\"request_id\":\"607a199fb7dc99e68af1196f659c23cf\",\"request_time\":\"2014-10-14 19:27:29\"}," +
                   "\"79371844901\":{\"id\":\"4115440762085900000001\",\"destination\":\"79371844901\",\"message_id\":\"l9likizqtxau2e5gbbho\",\"IMSI\":\"250017145699048\",\"stat\":\"DELIVRD\",\"error\":\"0\",\"orn\":\"Megafon\",\"pon\":\"MTS (Mobile TeleSystems)\",\"ron\":\"MTS (Mobile TeleSystems)\",\"mccmnc\":\"25001\",\"rcn\":\"Russian Federation\",\"ppm\":\"932\",\"onp\":\"93718\",\"ocn\":\"Russian Federation\",\"ocp\":\"7\",\"is_ported\":\"true\",\"rnp\":\"91701\",\"rcp\":\"7\",\"is_roaming\":\"false\",\"pnp\":\"79872500000\",\"pcn\":\"Russian Federation\",\"pcp\":\"7\",\"total_price\":\"0.2\",\"request_id\":\"79cdde57cea85f1cc2728f7c0d48f0bd\",\"request_time\":\"2014-09-24 11:34:36\"}}";
		}

		private string getErrorData()
		{
			return "{\"error\":4}";
		}
	}
}
