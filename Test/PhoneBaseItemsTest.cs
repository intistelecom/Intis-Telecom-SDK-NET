using System;
using Intis.SDK;
using Intis.SDK.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
	[TestClass]
	public class PhoneBaseItemsTest
	{
		const string Login = "your api login";
		const string ApiKey = "your api key here";
		const string ApiHost = "http://api.host.com/get/";

		[TestMethod]
		public void TestGetPhoneBaseItems()
		{
			IApiConnector connector = new LocalApiConnector(getData());

			var client = new IntisClient(Login, ApiKey, ApiHost, connector);

			var bases = client.GetPhoneBaseItems(125480, 2);
			foreach (var one in bases)
			{
				var phone = one.Phone;
				var firstName = one.FirstName;
				var middleName = one.MiddleName;
				var lastName = one.LastName;
				var birthDay = one.BirthDay;
				var area = one.Area;
				var gender = one.Gender;
				var network = one.Network;
				var note1 = one.Note1;
				var note2 = one.Note2;
			}

			Assert.IsNotNull(bases);
		}

		[TestMethod]
		[ExpectedException(typeof(PhoneBaseItemException))]
		public void TestGetPhoneBaseItemsException()
		{
			IApiConnector connector = new LocalApiConnector(getErrorData());

			var client = new IntisClient(Login, ApiKey, ApiHost, connector);

			client.GetPhoneBaseItems(125480, 2);
		}

		private string getData()
		{
			return "{\"78432956720\":{\"name\":\"\u0417\u0430\u0432\u0434\u0430\u0442\",\"last_name\":\"\u0421\u0430\u0445\u0430\u0432\u0435\u0442\u0434\u0438\u043d\u043e\u0432\",\"middle_name\":\"\u0411\u0430\u0433\u0430\u0432\u0435\u0442\u0434\u0438\u043d\u043e\u0432\u0438\u0447\",\"date_birth\":\"0000-00-00\",\"male\":\"m\",\"note1\":\"\",\"note2\":\"\",\"region\":null,\"operator\":null}," +
            "\"78432793843\":{\"name\":\"\u0413\u0435\u043d\u043d\u0430\u0434\u0438\u0439\",\"last_name\":\"\u042e\u0440\u044c\u0435\u0432\",\"middle_name\":\"\u0412\u0430\u0441\u0438\u043b\u044c\u0435\u0432\u0438\u0447\",\"date_birth\":\"0000-00-00\",\"male\":\"m\",\"note1\":\"\",\"note2\":\"\",\"region\":null,\"operator\":null}}";
		}

		private string getErrorData()
		{
			return "{\"error\":4}";
		}
	}
}
