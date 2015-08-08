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

using Intis.SDK.Entity;
using Intis.SDK.Exceptions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;

namespace Intis.SDK
{
	/// <summary>
	/// Class IntisClient
	/// The main class for SMS sending and getting API information
	/// </summary>
	public class IntisClient : AClient, IClient
	{
		/// <summary>
		/// Class constructor
		/// </summary>
		/// <param name="login">user login</param>
		/// <param name="apiKey">user API key</param>
		/// <param name="apiHost">API address</param>
		public IntisClient(string login, string apiKey, string apiHost)
			: base(null)
		{
			Login = login;
			ApiKey = apiKey;
			ApiHost = apiHost;
		}

		/// <summary>
		/// Class constructor
		/// </summary>
		/// <param name="login">user login</param>
		/// <param name="apiKey">user API key</param>
		/// <param name="apiHost">API address</param>
		/// <param name="apiConnector">API data connector</param>
		public IntisClient(string login, string apiKey, string apiHost, IApiConnector apiConnector)
			: base(apiConnector)
		{
			Login = login;
			ApiKey = apiKey;
			ApiHost = apiHost;
		}

		/// <summary>
		/// Getting user balance
		/// </summary>
		/// <returns>Balance</returns>
		public Balance GetBalance()
		{
			var parameters = new NameValueCollection();
			try
			{
				var content = GetStreamContent("balance", parameters);

				var serializer = new DataContractJsonSerializer(typeof(Balance));
				var balance = serializer.ReadObject(content) as Balance;

				return balance;
			}
			catch (Exception ex)
			{
				throw new BalanceException(parameters, ex);
			}
		}

		/// <summary>
		/// Getting all user lists
		/// </summary>
		/// <returns>List of phone base</returns>
		public List<PhoneBase> GetPhoneBases()
		{
			var parameters = new NameValueCollection();
			try
			{
				var content = GetStreamContent("base", parameters);

				var bases = new List<PhoneBase>();

				var settings = new DataContractJsonSerializerSettings
				{
					UseSimpleDictionaryFormat = true
				};

				var serializer = new DataContractJsonSerializer(typeof(Dictionary<Int64, PhoneBase>), settings);
				var phoneBases = serializer.ReadObject(content) as Dictionary<Int64, PhoneBase>;
				if (phoneBases == null)
					return bases;

				foreach (var one in phoneBases)
				{
					var oneBase = one.Value;
					oneBase.BaseId = one.Key;
					bases.Add(oneBase);
				}

				return bases;
			}
			catch (Exception ex)
			{
				throw new PhoneBasesException(parameters, ex);
			}
		}

		/// <summary>
		/// Getting all user sender names
		/// </summary>
		/// <returns>List of senders with its statuses</returns>
		public List<Originator> GetOriginators()
		{
			var parameters = new NameValueCollection();
			try
			{
				var content = GetContent("senders", parameters);

				var originators = new List<Originator>();

				var serializer = new JavaScriptSerializer();
				var list = serializer.Deserialize<Dictionary<string, string>>(content);

				originators.AddRange(list.Select(one => new Originator(one.Key, one.Value)));

				return originators;
			}
			catch (Exception ex)
			{
				throw new OriginatorException(parameters, ex);
			}
		}

		/// <summary>
		/// Getting subscribers of list
		/// </summary>
		/// <param name="baseId">List ID</param>
		/// <param name="page">Page of list</param>
		/// <returns>List subscribers</returns>
		public List<PhoneBaseItem> GetPhoneBaseItems(int baseId, int page = 1)
		{
			var parameters = new NameValueCollection()
            {
                {"base", baseId.ToString()},
                {"page", page.ToString()}
            };

			try
			{
				var content = GetStreamContent("phone", parameters);
				var phoneBaseItem = new List<PhoneBaseItem>();

				var settings = new DataContractJsonSerializerSettings
				{
					UseSimpleDictionaryFormat = true
				};

				var serializer = new DataContractJsonSerializer(typeof(Dictionary<Int64, PhoneBaseItem>), settings);
				var items = serializer.ReadObject(content) as Dictionary<Int64, PhoneBaseItem>;

				if (items == null)
					return phoneBaseItem;

				foreach (var one in items)
				{
					var item = one.Value;
					item.Phone = one.Key;
					phoneBaseItem.Add(item);
				}

				return phoneBaseItem;
			}
			catch (Exception ex)
			{
				throw new PhoneBaseItemException(parameters, ex);
			}
		}

		/// <summary>
		/// Getting message status
		/// </summary>
		/// <param name="messageId">Message ID</param>
		/// <returns>List of message status</returns>
		public List<DeliveryStatus> GetDeliveryStatus(string[] messageId)
		{
			var parameters = new NameValueCollection()
            {
                {"state", String.Join(",", messageId)}
            };

			try
			{
				var content = GetStreamContent("status", parameters);

				var deliveryStatus = new List<DeliveryStatus>();

				var settings = new DataContractJsonSerializerSettings
				{
					UseSimpleDictionaryFormat = true
				};

				var serializer = new DataContractJsonSerializer(typeof(Dictionary<string, DeliveryStatus>), settings);
				var items = serializer.ReadObject(content) as Dictionary<string, DeliveryStatus>;

				if (items == null)
					return deliveryStatus;

				foreach (var one in items)
				{
					var item = one.Value;
					item.MessageId = one.Key;
					deliveryStatus.Add(item);
				}

				return deliveryStatus;
			}
			catch (Exception ex)
			{
				throw new DeliveryStatusException(parameters, ex);
			}
		}

		/// <summary>
		/// SMS sending
		/// </summary>
		/// <param name="phone">Phone numbers</param>
		/// <param name="originator">Sender name</param>
		/// <param name="text">Sms text</param>
		/// <returns>Results list</returns>
		public List<MessageSendingResult> SendMessage(Int64[] phone, string originator, string text)
		{
			var parameters = new NameValueCollection()
            {
                {"phone", String.Join(",", phone.Select(p => p.ToString()))},
                {"sender", originator},
                {"text", text}
            };

			try
			{
				var content = GetStreamContent("send", parameters);

				var settings = new DataContractJsonSerializerSettings
				{
					UseSimpleDictionaryFormat = true
				};

				var messages = new List<MessageSendingResult>();

				var serializer = new DataContractJsonSerializer(typeof(Dictionary<Int64, MessageSending>[]), settings);
				var items = serializer.ReadObject(content) as Dictionary<Int64, MessageSending>[];

				if (items == null)
					return messages;

				foreach (var one in items)
				{
					var item = one.First().Value;
					item.Phone = one.First().Key;
					if (item.Error == 0)
					{
						var success = new MessageSendingSuccess
						{
							Phone = item.Phone,
							MessageId = item.MessageId,
							MessagesCount = item.MessagesCount,
							Cost = item.Cost,
							Currency = item.Currency
						};
						messages.Add(success);
					}
					else
					{
						var error = new MessageSendingError
						{
							Phone = item.Phone,
							Code = item.Error
						};
						messages.Add(error);
					}
				}

				return messages;
			}
			catch (Exception ex)
			{
				throw new MessageSendingResultException(parameters, ex);
			}
		}

		/// <summary>
		/// Testing phone number for stop list
		/// </summary>
		/// <param name="phone">Phone number</param>
		/// <returns>Stop list</returns>
		public StopList CheckStopList(Int64 phone)
		{
			var parameters = new NameValueCollection()
            {
                {"phone", phone.ToString()}
            };

			try
			{
				var content = GetStreamContent("find_on_stop", parameters);

				var settings = new DataContractJsonSerializerSettings
				{
					UseSimpleDictionaryFormat = true
				};

				var serializer = new DataContractJsonSerializer(typeof(Dictionary<Int64, StopList>), settings);
				var check = serializer.ReadObject(content) as Dictionary<Int64, StopList>;

				if (check == null || check.Count <= 0)
					return null;

				var one = check.First();
				var stopList = one.Value;
				stopList.Id = one.Key;

				return stopList;
			}
			catch (Exception ex)
			{
				throw new StopListException(parameters, ex);
			}
		}

		/// <summary>
		/// Adding number to stop list
		/// </summary>
		/// <param name="phone">Phone number</param>
		/// <returns>ID in stop list</returns>
		public Int64 AddToStopList(Int64 phone)
		{
			var parameters = new NameValueCollection()
            {
                {"phone", phone.ToString()}
            };

			try
			{
				var content = GetContent("add2stop", parameters);

				var serializer = new JavaScriptSerializer();
				var list = serializer.Deserialize<Dictionary<string, Int64>>(content);

				return list.First().Value;
			}
			catch (Exception ex)
			{
				throw new AddToStopListException(parameters, ex);
			}
		}

		/// <summary>
		/// Getting user templates
		/// </summary>
		/// <returns>List of templates</returns>
		public List<Template> GetTemplates()
		{
			var parameters = new NameValueCollection();

			try
			{
				var content = GetStreamContent("template", parameters);

				var settings = new DataContractJsonSerializerSettings
				{
					UseSimpleDictionaryFormat = true
				};

				var serializer = new DataContractJsonSerializer(typeof(Dictionary<Int64, Template>), settings);
				var items = serializer.ReadObject(content) as Dictionary<Int64, Template>;

				var list = new List<Template>();

				if (items == null)
					return list;

				foreach (var one in items)
				{
					var item = one.Value;
					item.Id = one.Key;
					list.Add(item);
				}

				return list;
			}
			catch (Exception ex)
			{
				throw new TemplateException(parameters, ex);
			}
		}

		/// <summary>
		/// Adding user template
		/// </summary>
		/// <param name="title">Template name</param>
		/// <param name="template">Text of template</param>
		/// <returns>ID in the template list</returns>
		public Int64 AddTemplate(string title, string template)
		{
			var parameters = new NameValueCollection()
            {
                {"name", title},
                {"text", template}
            };

			try
			{
				var content = GetContent("add_template", parameters);

				var serializer = new JavaScriptSerializer();
				var list = serializer.Deserialize<Dictionary<string, Int64>>(content);

				return list.First().Value;
			}
			catch (Exception ex)
			{
				throw new AddTemplateException(parameters, ex);
			}
		}

		/// <summary>
		/// Getting statistics for the certain month
		/// </summary>
		/// <param name="year">Year</param>
		/// <param name="month">Month</param>
		/// <returns>Statistics</returns>
		public List<DailyStats> GetDailyStatsByMonth(int year, int month)
		{
			var date = new DateTime(year, month, 1, 0, 0, 0);

			var parameters = new NameValueCollection()
            {
                {"month", date.ToString("yyyy-MM")}
            };

			try
			{
				var content = GetStreamContent("stat_by_month", parameters);

				var settings = new DataContractJsonSerializerSettings
				{
					UseSimpleDictionaryFormat = true
				};

				var serializer = new DataContractJsonSerializer(typeof(List<DailyStats>), settings);
				var items = serializer.ReadObject(content) as List<DailyStats>;

				return items;
			}
			catch (Exception ex)
			{
				throw new DailyStatsException(parameters, ex);
			}
		}

		/// <summary>
		/// Sending HLR request for number
		/// </summary>
		/// <param name="phone">Phone number</param>
		/// <returns>Results list</returns>
		public List<HlrResponse> MakeHlrRequest(Int64[] phone)
		{
			var parameters = new NameValueCollection()
            {
                {"phone", String.Join(",", phone.Select(p => p.ToString()))}
            };

			try
			{
				var content = GetStreamContent("hlr", parameters);

				var settings = new DataContractJsonSerializerSettings
				{
					UseSimpleDictionaryFormat = true
				};

				var serializer = new DataContractJsonSerializer(typeof(List<HlrResponse>), settings);
				var items = serializer.ReadObject(content) as List<HlrResponse>;

				return items;
			}
			catch (Exception ex)
			{
				throw new HlrResponseException(parameters, ex);
			}
		}

		/// <summary>
		/// Getting statuses of HLR request
		/// </summary>
		/// <param name="from">Initial date in the format YYYY-MM-DD</param>
		/// <param name="to">Final date in the format YYYY-MM-DD</param>
		/// <returns>Statuses</returns>
		public List<HlrStatItem> GetHlrStats(string from, string to)
		{
			var parameters = new NameValueCollection()
            {
                {"from", from},
                {"to", to}
            };

			try
			{
				var content = GetStreamContent("hlr_stat", parameters);

				var settings = new DataContractJsonSerializerSettings
				{
					UseSimpleDictionaryFormat = true
				};

				var list = new List<HlrStatItem>();

				var serializer = new DataContractJsonSerializer(typeof(Dictionary<Int64, HlrStatItem>), settings);
				var items = serializer.ReadObject(content) as Dictionary<Int64, HlrStatItem>;

				if (items == null)
					return list;

				list.AddRange(items.Select(one => one.Value));

				return list;
			}
			catch (Exception ex)
			{
				throw new HlrStatItemException(parameters, ex);
			}
		}

		/// <summary>
		/// Getting the operator of subscriber phone number
		/// </summary>
		/// <param name="phone">Phone number</param>
		/// <returns>Operator</returns>
		public Network GetNetworkByPhone(Int64 phone)
		{
			var parameters = new NameValueCollection()
            {
                {"phone", phone.ToString()}
            };

			try
			{
				var content = GetStreamContent("operator", parameters);

				var serializer = new DataContractJsonSerializer(typeof(Network));
				var network = serializer.ReadObject(content) as Network;

				return network;
			}
			catch (Exception ex)
			{
				throw new NetworkException(parameters, ex);
			}
		}

		/// <summary>
		/// Getting incoming messages of certain date
		/// </summary>
		/// <param name="date">Date in the format YYYY-MM-DD</param>
		/// <returns>List of incoming messages</returns>
		public List<IncomingMessage> GetIncomingMessages(string date)
		{
			var parameters = new NameValueCollection()
            {
                {"date", date}
            };

			try
			{
				var content = GetStreamContent("incoming", parameters);

				var settings = new DataContractJsonSerializerSettings
				{
					UseSimpleDictionaryFormat = true
				};

				var list = new List<IncomingMessage>();

				var serializer = new DataContractJsonSerializer(typeof(Dictionary<string, IncomingMessage>), settings);
				var items = serializer.ReadObject(content) as Dictionary<string, IncomingMessage>;

				if (items == null)
					return list;

				foreach (var one in items)
				{
					var message = one.Value;
					message.MessageId = one.Key;
					list.Add(one.Value);
				}

				return list;
			}
			catch (Exception ex)
			{
				throw new IncomingMessageException(parameters, ex);
			}
		}
	}
}
