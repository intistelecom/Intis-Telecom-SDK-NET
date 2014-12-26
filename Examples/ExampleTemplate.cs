using Intis.SDK;
using Intis.SDK.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples
{
	class ExampleTemplate
	{
		static void GetTemplates()
		{
			string login = "rso";
			string apiKey = "cfe4fb6f670914b7897cc2783234b7428d6dc826";
			string apiHost = "http://dev.sms16.ru/get/";
			IntisClient client = new IntisClient(login, apiKey, apiHost);

			List<Template> templates = client.getTemplates();
			foreach (Template one in templates)
			{
				one.getId();
				var t = one.getTitle();
				var y = one.getTemplate();
				one.getCreatedAt();
			}
		}
	}
}
