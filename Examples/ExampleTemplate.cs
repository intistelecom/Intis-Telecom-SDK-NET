using Intis.SDK;

namespace Examples
{
	class ExampleTemplate
	{
		static void GetTemplates()
		{
			const string login = "rso";
			const string apiKey = "cfe4fb6f670914b7897cc2783234b7428d6dc826";
			const string apiHost = "http://dev.sms16.ru/get/";
			var client = new IntisClient(login, apiKey, apiHost);

            var templates = client.GetTemplates();
            foreach (var one in templates)
            {
                var id = one.Id;
                var title = one.Title;
                var template = one.template;
                var createdAt = one.CreatedAt;
            }
		}
	}
}
