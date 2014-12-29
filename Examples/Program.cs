using Intis.SDK;
using System.Collections;
using System.Collections.Generic;
using Intis.SDK.Entity;
using Intis.SDK.Exceptions;

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

            var phones = new[] { 79802503672, 98889995522 };
            try
            {
                var status = client.SendMessage(phones, "smstest", "test").ToArray();
                foreach (var one in status)
                {
                    if (one.IsOk)
                    {
                        var success = (MessageSendingSuccess) one;
                        var phone = success.Phone;
                        var messageId = success.MessageId;
                        var messagesCount = success.MessagesCount;
                        var cost = success.Cost;
                        var currency = success.Currency;
                    }
                    else
                    {
                        var error = (MessageSendingError) one;
                        var phone = one.Phone;
                        var errorCode = error.Code;
                        var errorMessage = error.Message;
                    }
                }
            }
            catch (MessageSendingResultException ex)
            {
                var message = ex.Message;
                var code = ex.Parameters;
            }
            catch (SdkException ex)
            {
                var code = ex.Code;
                var message = ex.Message;
            }
        }
    }
}
