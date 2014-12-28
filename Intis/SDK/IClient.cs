using System;
using System.Collections.Generic;
using Intis.SDK.Entity;

namespace Intis.SDK
{
    public interface IClient
    {
        /// <summary>
        /// Get balance
        /// </summary>
        /// <returns>Balance</returns>
        Balance GetBalance();

        /// <summary>
        /// Get lists
        /// </summary>
        /// <returns>PhoneBase[]</returns>
        List<PhoneBase> GetPhoneBases();

        /// <summary>
        /// Get sender names
        /// </summary>
        /// <returns>Originator[]</returns>
        List<Originator> GetOriginators();

        /// <summary>
        /// Get phone numbers from list
        /// </summary>
        /// <param name="baseId">List ID</param>
        /// <param name="page">Page number</param>
        /// <returns>PhoneBaseItem[]</returns>
        List<PhoneBaseItem> GetPhoneBaseItems(int baseId, int page);

        /// <summary>
        /// Get information of message status
        /// </summary>
        /// <param name="messageId">Message ID</param>
        /// <returns>PhoneBaseItem[]</returns>
        List<DeliveryStatus> GetDeliveryStatus(string[] messageId);

        /// <summary>
        /// Send a message
        /// </summary>
        /// <param name="phone">Phone number</param>
        /// <param name="originator">Sender name (one of the approved in your account)</param>
        /// <param name="text">SMS text</param>
        /// <returns>Message ID</returns>
        List<MessageSendingResult> SendMessage(Int64[] phone, string originator, string text);

        /// <summary>
        /// Search of number in stop list
        /// </summary>
        /// <param name="phone">Phone number</param>
        /// <returns>StopList</returns>
        StopList CheckStopList(Int64 phone);

        /// <summary>
        /// Add number to stop list
        /// </summary>
        /// <param name="phone">Phone number</param>
        /// <returns>ID</returns>
        Int64 AddToStopList(Int64 phone);

        /// <summary>
        /// Get list of templates
        /// </summary>
        /// <returns>Template[]</returns>
        List<Template> GetTemplates();

        /// <summary>
        /// Add a template
        /// </summary>
        /// <param name="title">Template name</param>
        /// <param name="template">Template</param>
        /// <returns>ID</returns>
        Int64 AddTemplate(string title, string template);

        /// <summary>
        /// Get statistics for a month by days
        /// </summary>
        /// <param name="year">Year</param>
        /// <param name="month">Month</param>
        /// <returns>DailyStats[]</returns>
        List<DailyStats> GetDailyStatsByMonth(int year, int month);

        /// <summary>
        /// HLR request
        /// </summary>
        /// <param name="phone">Phone number</param>
        /// <returns>HLRResponse[]</returns>
        List<HlrResponse> MakeHlrRequest(Int64[] phone);

        /// <summary>
        /// Statistics of HLR requests
        /// </summary>
        /// <param name="from">Initial date in the format YYYY-MM-DD</param>
        /// <param name="to">Final date in the format YYYY-MM-DD</param>
        /// <returns>HLRStatItem[]</returns>
        List<HlrStatItem> GetHlrStats(string from, string to);

        /// <summary>
        /// Get operator
        /// </summary>
        /// <param name="phone">Phone number</param>
        /// <returns>Network</returns>
        Network GetNetworkByPhone(Int64 phone);

        /// <summary>
        /// Get incoming SMS
        /// </summary>
        /// <param name="date">Date in the format YYYY-MM-DD</param>
        /// <returns>IncomingMessage[]</returns>
        List<IncomingMessage> GetIncomingMessages(string date);
    }
}
