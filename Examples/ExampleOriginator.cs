using Intis.SDK;
using Intis.SDK.Exceptions;

namespace Examples
{
	class ExampleOriginator
	{
		static void GetOriginator()
		{
            const string login = "your api login";
            const string apiKey = "your api key here";
            const string apiHost = "http://api.host.com/get/";

			var client = new IntisClient(login, apiKey, apiHost);

		    try
		    {
		        var originators = client.GetOriginators();
		        foreach (var one in originators)
		        {
		            var name = one.Name;
		            var state = one.State;
		        }
            }
            catch (OriginatorException ex)
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
