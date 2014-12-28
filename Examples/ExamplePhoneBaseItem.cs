using Intis.SDK;

namespace Examples
{
	class ExamplePhoneBaseItem
	{
		static void GetPhoneBaseItem()
		{
			const string login = "rso";
			const string apiKey = "cfe4fb6f670914b7897cc2783234b7428d6dc826";
			const string apiHost = "http://dev.sms16.ru/get/";

			var client = new IntisClient(login, apiKey, apiHost);

            var bases = client.GetPhoneBaseItems(125480, 2);
            foreach (var one in bases)
            {
                var phone = one.Phone;
                var firstName = one.FirstName;
                var middleName = one.MiddleName;
                var lastName = one.LastName;
                var birthDay = one.BirthDay;
                var area = one.Area;
                var gender= one.Gender;
                var network = one.Network;
                var note1= one.Note1;
                var note2= one.Note2;
            }
		}
	}
}
