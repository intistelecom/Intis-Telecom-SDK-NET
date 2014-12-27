using Intis.SDK;
using Intis.SDK.Entity;
using System;
using System.Collections.Generic;

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


            Int64[] phones = new Int64[] { 79800000000 };
            List<HLRResponse> HLRResponse = client.makeHLRRequest(phones);
            foreach (HLRResponse one in HLRResponse)
            {
                one.getId();
                one.getIMSI();
                one.getDestination();
                one.getMCC();
                one.getMNC();
                one.getOriginalCountryCode();
                one.getOriginalCountryName();
                one.getOriginalNetworkName();
                one.getOriginalNetworkPrefix();
                one.getPortedCountryName();
                one.getPortedCountryPrefix();
                one.getPortedNetworkName();
                one.getPortedNetworkPrefix();
                one.getPricePerMessage();
                one.getRoamingCountryName();
                one.getRoamingCountryPrefix();
                one.getRoamingNetworkName();
                one.getRoamingNetworkPrefix();
                one.getStatus();
                one.isPorted();
                one.isInRoaming();
            }
        }
    }
}
