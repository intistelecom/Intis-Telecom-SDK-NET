using Intis.SDK.Entity;
using Intis.SDK.Exceptions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;

namespace Intis.SDK
{
    public class IntisClient : AClient, IClient
    {
        public IntisClient(string login, string apiKey, string apiHost)
        {
            this.login = login;
            this.apiKey = apiKey;
            this.apiHost = apiHost;
        }

        public Balance getBalance()
        {
            NameValueCollection parameters = new NameValueCollection();
            MemoryStream content = this.getStreamContent("balance", parameters);

            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Balance));
                Balance balance = serializer.ReadObject(content) as Balance;

                return balance;
            }
            catch (SerializationException ex)
            {
                throw new BalanceException(parameters, ex);
            }
        }

        public List<PhoneBase> getPhoneBases()
        {
            NameValueCollection parameters = new NameValueCollection();
            MemoryStream content = this.getStreamContent("base", parameters);

            List<PhoneBase> bases = new List<PhoneBase>();

            DataContractJsonSerializerSettings settings = new DataContractJsonSerializerSettings();
            settings.UseSimpleDictionaryFormat = true;
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Dictionary<Int64, PhoneBase>), settings);
                Dictionary<Int64, PhoneBase> phoneBases = serializer.ReadObject(content) as Dictionary<Int64, PhoneBase>;
                foreach (var one in phoneBases)
                {
                    PhoneBase oneBase = one.Value;
                    oneBase.baseId = one.Key;
                    bases.Add(oneBase);
                }

                return bases;
            }
            catch (SerializationException ex)
            {
                throw new PhoneBasesException(parameters, ex);
            }
        }

        public List<Originator> getOriginators()
        {
            NameValueCollection parameters = new NameValueCollection();
            string content = this.getContent("senders", parameters);

            List<Originator> originators = new List<Originator>();
            Dictionary<string, string> list = new Dictionary<string, string>();

            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                list = serializer.Deserialize<Dictionary<string, string>>(content);

                foreach (var one in list)
                {
                    originators.Add(new Originator(one.Key, one.Value));
                }

                return originators;
            }
            catch (SerializationException ex)
            {
                throw new OriginatorException(parameters, ex);
            }
        }

        public List<PhoneBaseItem> getPhoneBaseItems(int baseId, int page = 1)
        {
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("base", baseId.ToString());
            parameters.Add("page", page.ToString());

            MemoryStream content = this.getStreamContent("phone", parameters);
            List<PhoneBaseItem> phoneBaseItem = new List<PhoneBaseItem>();

            DataContractJsonSerializerSettings settings = new DataContractJsonSerializerSettings();
            settings.UseSimpleDictionaryFormat = true;
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Dictionary<Int64, PhoneBaseItem>), settings);
                Dictionary<Int64, PhoneBaseItem> items = serializer.ReadObject(content) as Dictionary<Int64, PhoneBaseItem>;
                foreach (var one in items)
                {
                    PhoneBaseItem item = one.Value;
                    item.phone = one.Key;
                    phoneBaseItem.Add(item);
                }

                return phoneBaseItem;
            }
            catch (SerializationException ex)
            {
                throw new PhoneBaseItemException(parameters, ex);
            }
        }

        public List<DeliveryStatus> getDeliveryStatus(string[] messageId)
        {
            NameValueCollection parameters = new NameValueCollection();
            string messageIdStr = String.Join(",", messageId);
            parameters.Add("state", messageIdStr);

            MemoryStream content = this.getStreamContent("status", parameters);

            List<DeliveryStatus> deliveryStatus = new List<DeliveryStatus>();

            DataContractJsonSerializerSettings settings = new DataContractJsonSerializerSettings();
            settings.UseSimpleDictionaryFormat = true;
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Dictionary<string, DeliveryStatus>), settings);
                Dictionary<string, DeliveryStatus> items = serializer.ReadObject(content) as Dictionary<string, DeliveryStatus>;
                foreach (var one in items)
                {
                    DeliveryStatus item = one.Value;
                    item.messageId = one.Key;
                    deliveryStatus.Add(item);
                }

                return deliveryStatus;
            }
            catch (SerializationException ex)
            {
                throw new DeliveryStatusException(parameters, ex);
            }
        }

        public List<MessageSendingResult> sendMessage(Int64[] phone, string originator, string text)
        {
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("phone", String.Join(",", phone.Select(p => p.ToString())));
            parameters.Add("sender", originator);
            parameters.Add("text", text);

            MemoryStream content = this.getStreamContent("send", parameters);

            DataContractJsonSerializerSettings settings = new DataContractJsonSerializerSettings();
            settings.UseSimpleDictionaryFormat = true;
            try
            {
                List<MessageSendingResult> messages = new List<MessageSendingResult>();

                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Dictionary<Int64, MessageSendingResult>[]), settings);
                Dictionary<Int64, MessageSendingResult>[] items = serializer.ReadObject(content) as Dictionary<Int64, MessageSendingResult>[];
                foreach (var one in items)
                {
                    MessageSendingResult item = one.First().Value;
                    item.phone = one.First().Key;
                    messages.Add(item);
                }

                return messages;
            }
            catch (SerializationException ex)
            {
                throw new MessageSendingResultException(parameters, ex);
            }
        }

        public StopList checkStopList(Int64 phone)
        {
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("phone", phone.ToString());

            MemoryStream content = this.getStreamContent("find_on_stop", parameters);

            DataContractJsonSerializerSettings settings = new DataContractJsonSerializerSettings();
            settings.UseSimpleDictionaryFormat = true;
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Dictionary<Int64, StopList>), settings);
                Dictionary<Int64, StopList> check = serializer.ReadObject(content) as Dictionary<Int64, StopList>;

                StopList stopList = null;
                if (check.Count > 0)
                {
                    var one = check.First();
                    stopList = one.Value;
                    stopList.id = one.Key;
                }

                return stopList;
            }
            catch (SerializationException ex)
            {
                throw new StopListException(parameters, ex);
            }
        }

		public Int64 addToStopList(Int64 phone)
		{
			NameValueCollection parameters = new NameValueCollection();
			parameters.Add("phone", phone.ToString());

			string content = this.getContent("add2stop", parameters);

			try
			{
				JavaScriptSerializer serializer = new JavaScriptSerializer();
				Dictionary<string, Int64> list = serializer.Deserialize<Dictionary<string, Int64>>(content);

				return list.First().Value;
			}
			catch (SerializationException ex)
			{
				throw new AddToStopListException(parameters, ex);
			}
		}

		public List<Template> getTemplates()
		{
			NameValueCollection parameters = new NameValueCollection();

			MemoryStream content = this.getStreamContent("template", parameters);

			DataContractJsonSerializerSettings settings = new DataContractJsonSerializerSettings();
			settings.UseSimpleDictionaryFormat = true;
			try
			{
				DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Dictionary<Int64, Template>), settings);
				Dictionary<Int64, Template> items = serializer.ReadObject(content) as Dictionary<Int64, Template>;

				List<Template> list = new List<Template>();

				foreach (var one in items)
				{
					Template item = one.Value;
					item.id = one.Key;
					list.Add(item);
				}

				return list;
			}
			catch (SerializationException ex)
			{
				throw new TemplateException(parameters, ex);
			}
		}

		public Int64 addTemplate(string title, string template)
		{
			NameValueCollection parameters = new NameValueCollection();
			parameters.Add("name", title);
			parameters.Add("text", template);

			string content = this.getContent("add_template", parameters);

			try
			{
				JavaScriptSerializer serializer = new JavaScriptSerializer();
				Dictionary<string, Int64> list = serializer.Deserialize<Dictionary<string, Int64>>(content);

				return list.First().Value;
			}
			catch (SerializationException ex)
			{
				throw new AddTemplateException(parameters, ex);
			}
		}

        public List<DailyStats> getDailyStatsByMonth(int year, int month)
        {
            DateTime date = new DateTime(year, month, 1, 0, 0, 0);

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("month", date.ToString("yyyy-MM"));

            MemoryStream content = this.getStreamContent("stat_by_month", parameters);

            DataContractJsonSerializerSettings settings = new DataContractJsonSerializerSettings();
            settings.UseSimpleDictionaryFormat = true;
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Dictionary<string, Dictionary<string, Stats[]>[]>[]), settings);
                Dictionary<string, Dictionary<string, Stats[]>[]>[] items = serializer.ReadObject(content) as Dictionary<string, Dictionary<string, Stats[]>[]>[];

                List<DailyStats> list = new List<DailyStats>();

                foreach (var one in items)
                {
                    var stateDate = one.First();
                    DailyStats item = new DailyStats(stateDate);
                    list.Add(item);
                }

                return list;
            }
            catch (SerializationException ex)
            {
                throw new DailyStatsException(parameters, ex);
            }
        }

        public List<HLRResponse> makeHLRRequest(Int64[] phone)
        {
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("phone", String.Join(",", phone.Select(p => p.ToString())));

            MemoryStream content = this.getStreamContent("hlr", parameters);

            DataContractJsonSerializerSettings settings = new DataContractJsonSerializerSettings();
            settings.UseSimpleDictionaryFormat = true;
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Dictionary<Int64, HLRResponse>), settings);
                List<HLRResponse> items = serializer.ReadObject(content) as List<HLRResponse>;

                return items;
            }
            catch (SerializationException ex)
            {
                throw new HLRResponseException(parameters, ex);
            }
        }

        public List<HLRStatItem> getHlrStats(string from, string to)
        {
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("from", from);
            parameters.Add("to", to);

            MemoryStream content = this.getStreamContent("hlr_stat", parameters);

            DataContractJsonSerializerSettings settings = new DataContractJsonSerializerSettings();
            settings.UseSimpleDictionaryFormat = true;
            try
            {
                List<HLRStatItem> list = new List<HLRStatItem>();

                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Dictionary<Int64, HLRStatItem>), settings);
                Dictionary<Int64, HLRStatItem> items = serializer.ReadObject(content) as Dictionary<Int64, HLRStatItem>;

                foreach (var one in items)
                {
                    list.Add(one.Value);
                }

                return list;
            }
            catch (SerializationException ex)
            {
                throw new HLRStatItemException(parameters, ex);
            }
        }

        public Network getNetworkByPhone(Int64 phone)
        {
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("phone", phone.ToString());

            MemoryStream content = this.getStreamContent("operator", parameters);

            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Network));
                Network network = serializer.ReadObject(content) as Network;

                return network;
            }
            catch (SerializationException ex)
            {
                throw new NetworkException(parameters, ex);
            }
        }

        public List<IncomingMessage> getIncomingMessages(string date)
        {
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("date", date);

            MemoryStream content = this.getStreamContent("incoming", parameters);

            DataContractJsonSerializerSettings settings = new DataContractJsonSerializerSettings();
            settings.UseSimpleDictionaryFormat = true;
            try
            {
                List<IncomingMessage> list = new List<IncomingMessage>();

                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Dictionary<string, IncomingMessage>), settings);
                Dictionary<string, IncomingMessage> items = serializer.ReadObject(content) as Dictionary<string, IncomingMessage>;

                foreach (var one in items)
                {
                    IncomingMessage message = one.Value;
                    message.messageId = one.Key;
                    list.Add(one.Value);
                }

                return list;
            }
            catch (SerializationException ex)
            {
                throw new IncomingMessageException(parameters, ex);
            }
        }
    }
}
