using System;
using Intis.SDK;
using Intis.SDK.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
	[TestClass]
	public class PhoneBasesTest
	{
		const string Login = "your api login";
		const string ApiKey = "your api key here";
		const string ApiHost = "http://api.host.com/get/";

		[TestMethod]
		public void TestGetPhoneBases()
		{
			IApiConnector connector = new LocalApiConnector(getData());

			var client = new IntisClient(Login, ApiKey, ApiHost, connector);

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

		[TestMethod]
		[ExpectedException(typeof(PhoneBasesException))]
		public void TestGetPhoneBasesException()
		{
			IApiConnector connector = new LocalApiConnector(getErrorData());

			var client = new IntisClient(Login, ApiKey, ApiHost, connector);

			client.GetPhoneBases();
		}

		private string getData()
		{
			return "{\"125480\":{\"name\":\"989878979\",\"time_birth\":\"12:00:00\",\"day_before\":\"0\",\"local_time\":\"1\",\"birth_sender\":\"\",\"birth_text\":\"\",\"on_birth\":\"0\",\"count\":\"0\",\"pages\":0}," +
            "\"125473\":{\"name\":\"654564\",\"time_birth\":\"12:00:00\",\"day_before\":\"0\",\"local_time\":\"1\",\"birth_sender\":\"\",\"birth_text\":\"\",\"on_birth\":\"0\",\"count\":\"367\",\"pages\":4}}";
		}

		private string getErrorData()
		{
			return "{\"error\":4}";
		}
	}
}
