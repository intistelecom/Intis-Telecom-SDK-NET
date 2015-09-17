// The MIT License (MIT)
// Copyright (c) 2015 Intis Telecom
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

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
            return "{\"442073238000\":{\"name\":\"Jon\",\"last_name\":\"Voight\",\"middle_name\":\"\",\"date_birth\":\"0000-00-00\",\"male\":\"m\",\"note1\":\"\",\"note2\":\"\",\"region\":null,\"operator\":null}," +
            "\"442073238001\":{\"name\":\"Jon\",\"last_name\":\"Voight\",\"middle_name\":\"\",\"date_birth\":\"0000-00-00\",\"male\":\"m\",\"note1\":\"\",\"note2\":\"\",\"region\":null,\"operator\":null}}";
		}

		private string getErrorData()
		{
			return "{\"error\":4}";
		}
	}
}
