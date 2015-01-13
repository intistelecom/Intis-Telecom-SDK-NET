using Intis.SDK;
using Intis.SDK.Exceptions;

namespace Examples
{
	class ExampleAddTemplate
	{
		static void AddTemplate()
		{
            const string login = "your api login";
            const string apiKey = "your api key here";
			const string apiHost = "http://api.host.com/get/";
			var client = new IntisClient(login, apiKey, apiHost);

		    try
		    {
		        var template = client.AddTemplate("test", "this is test");
		    }
		    catch (TemplateException ex)
		    {
		        var message = ex.Message;
		        var parameters = ex.Parameters;
		    }
		    catch (SdkException ex)
		    {
		        var code = ex.Code;
		        var message = ex.Message;
		    }
		}
	}
}
