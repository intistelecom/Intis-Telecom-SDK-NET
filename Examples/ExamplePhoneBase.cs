using Intis.SDK;

namespace Examples
{
	class ExamplePhoneBase
	{
		static void GetPhoneBase()
		{
			const string login = "rso";
			const string apiKey = "cfe4fb6f670914b7897cc2783234b7428d6dc826";
			const string apiHost = "http://dev.sms16.ru/get/";

			var client = new IntisClient(login, apiKey, apiHost);

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
	}
}
