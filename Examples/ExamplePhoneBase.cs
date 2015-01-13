using Intis.SDK;
using Intis.SDK.Exceptions;

namespace Examples
{
	class ExamplePhoneBase
	{
		static void GetPhoneBase()
		{
            const string login = "your api login";
            const string apiKey = "your api key here";
            const string apiHost = "http://api.host.com/get/";

			var client = new IntisClient(login, apiKey, apiHost);

		    try
		    {
		        var balance = client.GetPhoneBases();
		        foreach (var one in balance)
		        {
		            var baseId = one.BaseId;
		            var title = one.Title;
		            var count = one.Count;
		            var pages = one.Pages;
		            var birthday = one.BirthdayGreetingSettings;
		            var enabled = birthday.Enabled;
		            var originator = birthday.Originator;
		            var daysBefore = birthday.DaysBefore;
		            var timeToSend = birthday.TimeToSend;
		            var useLocalTime = birthday.UseLocalTime;
		            var template = birthday.Template;
		        }
		    }
            catch (PhoneBasesException ex)
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
