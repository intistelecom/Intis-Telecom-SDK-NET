using Intis.SDK.Entity;
using Intis.SDK.Exceptions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;

namespace Intis.SDK
{
	public class IntisClient : AClient, IClient
	{
		public IntisClient(string login, string apiKey, string apiHost)
			: base(null)
		{
			Login = login;
			ApiKey = apiKey;
			ApiHost = apiHost;
		}
		public IntisClient(string login, string apiKey, string apiHost, IApiConnector apiConnector)
			: base(apiConnector)
		{
			Login = login;
			ApiKey = apiKey;
			ApiHost = apiHost;
		}

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

				var serializer = new DataContractJsonSerializer(typeof(List<DeliveryStatus>), settings);
				var items = serializer.ReadObject(content) as List<DeliveryStatus>;

				if (items == null)
					return deliveryStatus;

				deliveryStatus.AddRange(items);

				return deliveryStatus;
			}
			catch (Exception ex)
			{
				throw new DeliveryStatusException(parameters, ex);
			}
		}

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
