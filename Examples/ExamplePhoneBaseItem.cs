using Intis.SDK;
using Intis.SDK.Exceptions;

namespace Examples
{
	class ExamplePhoneBaseItem
	{
		static void GetPhoneBaseItem()
		{
            const string login = "your api login";
            const string apiKey = "your api key here";
            const string apiHost = "http://api.host.com/get/";

			var client = new IntisClient(login, apiKey, apiHost);

            try {
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
            catch (PhoneBaseItemException ex)
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
