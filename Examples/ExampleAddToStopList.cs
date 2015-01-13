using Intis.SDK;
using Intis.SDK.Exceptions;

namespace Examples
{
	class ExampleAddToStopList
	{
		static void AddToStoplist()
		{
            const string login = "your api login";
            const string apiKey = "your api key here";
            const string apiHost = "http://api.host.com/get/";
			var client = new IntisClient(login, apiKey, apiHost);

		    try
		    {
		        var list = client.AddToStopList(79009009096);
		    }
		    catch (AddToStopListException ex)
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
