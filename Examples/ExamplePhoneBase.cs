using Intis.SDK;
using Intis.SDK.Entity;
using System.Collections.Generic;

namespace Examples
{
	class ExamplePhoneBase
	{
		static void GetPhoneBase()
		{
			string login = "rso";
			string apiKey = "cfe4fb6f670914b7897cc2783234b7428d6dc826";
			string apiHost = "http://dev.sms16.ru/get/";

			IntisClient client = new IntisClient(login, apiKey, apiHost);

			List<PhoneBase> balance = client.getPhoneBases();
			foreach (PhoneBase one in balance)
			{
				one.getBaseId();
				one.getTitle();
				one.getCount();
				one.getPages();
				BirthdayGreetingSettings birthday = one.getBirthdayGreetingSettings();
				birthday.getEnebled();
				birthday.getOriginator();
				birthday.getDaysBefore();
				birthday.getTimeToSend();
				birthday.getUselocalTime();
				birthday.getTemplate();
			}
		}
	}
}
