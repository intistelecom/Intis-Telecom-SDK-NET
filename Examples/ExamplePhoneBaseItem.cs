using Intis.SDK;
using Intis.SDK.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples
{
	class ExamplePhoneBaseItem
	{
		static void GetPhoneBaseItem()
		{
			string login = "rso";
			string apiKey = "cfe4fb6f670914b7897cc2783234b7428d6dc826";
			string apiHost = "http://dev.sms16.ru/get/";

			IntisClient client = new IntisClient(login, apiKey, apiHost);

            //List<PhoneBaseItem> bases = client.getPhoneBaseItems(125480, 1);
            //foreach (PhoneBaseItem one in bases)
            //{
            //    one.getPhone();
            //    one.getFirstName();
            //    one.getMiddleName();
            //    one.getLastName();
            //    one.getBirthDay();
            //    one.getArea();
            //    one.getGender();
            //    one.getNetwork();
            //    one.getNote1();
            //    one.getNote2();
            //}
		}
	}
}
