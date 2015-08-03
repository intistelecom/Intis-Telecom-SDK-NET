using Intis.SDK;
using Intis.SDK.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
	[TestClass]
	public class BalanceTest
	{
		const string Login = "your api login";
		const string ApiKey = "your api key here";
		const string ApiHost = "http://api.host.com/get/";

		[TestMethod]
		public void TestGetBalabce()
		{

			IApiConnector connector = new LocalApiConnector(getData());

			var client = new IntisClient(Login, ApiKey, ApiHost, connector);

			var balance = client.GetBalance();
			var amount = balance.Amount;
			var currency = balance.Currency;

			Assert.IsNotNull(balance);
		}

		[TestMethod]
		[ExpectedException(typeof(BalanceException))]
		public void TestGetBalabceException()
		{
			IApiConnector connector = new LocalApiConnector(getErrorData());

			var client = new IntisClient(Login, ApiKey, ApiHost, connector);

			client.GetBalance();
		}

		private string getData()
		{
			return "{\"money\":4, \"currency\":\"RUB\"}";
		}

		private string getErrorData()
		{
			return "{\"error\":4}";
		}
	}
}
