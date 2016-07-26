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

using System;
using System.Collections.Generic;
using Intis.SDK.Entity;

namespace Intis.SDK
{
	/// <summary>
	/// Interface IClient
	/// Class with methods of receiving SDK information
	/// </summary>
    public interface IClient
    {
        /// <summary>
        /// Get balance
        /// </summary>
        /// <returns>Balance</returns>
        Balance GetBalance();

        /// <summary>
		/// Getting all user lists
        /// </summary>
		/// <returns>list of phone base</returns>
        List<PhoneBase> GetPhoneBases();

        /// <summary>
		/// Getting all user sender names
        /// </summary>
		/// <returns>List of senders with its statuses</returns>
        List<Originator> GetOriginators();

        /// <summary>
		/// Getting subscribers of list
        /// </summary>
        /// <param name="baseId">List ID</param>
		/// <param name="page">Page of list</param>
		/// <returns>List subscribers</returns>
        List<PhoneBaseItem> GetPhoneBaseItems(int baseId, int page);

        /// <summary>
		/// Getting message status
        /// </summary>
        /// <param name="messageId">Message ID</param>
		/// <returns>List of message status</returns>
        List<DeliveryStatus> GetDeliveryStatus(string[] messageId);

        /// <summary>
		/// SMS sending
        /// </summary>
        /// <param name="phone">Phone number</param>
        /// <param name="originator">Sender name (one of the approved in your account)</param>
        /// <param name="text">SMS text</param>
		/// <returns>Results list</returns>
        List<MessageSendingResult> SendMessage(Int64[] phone, string originator, string text);

        /// <summary>
		/// Testing phone number for stop list
        /// </summary>
        /// <param name="phone">Phone number</param>
		/// <returns>Stop list</returns>
        StopList CheckStopList(Int64 phone);

        /// <summary>
		/// Adding number to stop list
        /// </summary>
        /// <param name="phone">Phone number</param>
		/// <returns>ID in stop list</returns>
        Int64 AddToStopList(Int64 phone);

        /// <summary>
		/// Getting user templates
        /// </summary>
		/// <returns>List of templates</returns>
        List<Template> GetTemplates();

        /// <summary>
		/// Adding user template
        /// </summary>
        /// <param name="title">Template name</param>
		/// <param name="template">Text of template</param>
		/// <returns>ID in the template list</returns>
        Int64 AddTemplate(string title, string template);

	    /// <summary>
	    /// Remove user template
	    /// </summary>
	    /// <param name="name">Template name</param>
	    /// <returns>Result</returns>
	    RemoveTemplateResponse RemoveTemplate(string name);

        /// <summary>
        /// Getting statistics for the certain month
        /// </summary>
        /// <param name="year">Year</param>
        /// <param name="month">Month</param>
        /// <returns>Statistics</returns>
        List<DailyStats> GetDailyStatsByMonth(int year, int month);

        /// <summary>
		/// Sending HLR request for number
        /// </summary>
        /// <param name="phone">Phone number</param>
		/// <returns>Results list</returns>
        List<HlrResponse> MakeHlrRequest(Int64[] phone);

        /// <summary>
		/// Getting statuses of HLR request
        /// </summary>
        /// <param name="from">Initial date in the format YYYY-MM-DD</param>
        /// <param name="to">Final date in the format YYYY-MM-DD</param>
		/// <returns>statuses</returns>
        List<HlrStatItem> GetHlrStats(string from, string to);

        /// <summary>
		/// Getting the operator of subscriber phone number
        /// </summary>
        /// <param name="phone">Phone number</param>
		/// <returns>Operator</returns>
        Network GetNetworkByPhone(Int64 phone);

        /// <summary>
		/// Getting incoming messages of certain date
        /// </summary>
        /// <param name="date">Date in the format YYYY-MM-DD</param>
		/// <returns>List of incoming messages</returns>
        List<IncomingMessage> GetIncomingMessages(string date);
    }
}
