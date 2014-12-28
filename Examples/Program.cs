using Intis.SDK;

namespace Examples
{
    class Program
    {
        static void Main()
        {
            const string login = "rso";
            const string apiKey = "cfe4fb6f670914b7897cc2783234b7428d6dc826";
            const string apiHost = "http://dev.sms16.ru/get/";
            var client = new IntisClient(login, apiKey, apiHost);

            var balance = client.GetBalance();
            var amount = balance.Amount;
            var currency = balance.Currency;
        }
    }
}
