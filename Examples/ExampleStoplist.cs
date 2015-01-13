using Intis.SDK;
using Intis.SDK.Exceptions;

namespace Examples
{
	class ExampleStoplist
	{
		static void CheckstopList()
		{
            const string login = "your api login";
            const string apiKey = "your api key here";
            const string apiHost = "http://api.host.com/get/";
			var client = new IntisClient(login, apiKey, apiHost);

            try {
                var list = client.CheckStopList(79009009090);
                var id = list.Id;
                var timeAddedAt = list.TimeAddedAt;
                var description= list.Description;
            }
            catch (StopListException ex)
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
