using System;
using System.Collections.Generic;
using System.Linq;
using Intis.SDK.Entity;
using System.Collections.Specialized;
using Newtonsoft.Json.Linq;
using System.Numerics;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Web;
using System.Web.Script.Serialization;

namespace Intis.SDK
{
    public class IntisClient : AClient//, IClient
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
                _logger.Error("Error [getBalance]: " + ex.Message);
                if (ex.InnerException != null)
                    _logger.Error("Inner error: " + ex.InnerException.Message);
                _logger.Error("Parameters [" + String.Join(", ", parameters.AllKeys.Select(a => a + "=" + parameters[a])) + "]");
                throw ex;
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
                _logger.Error("Error [getPhoneBases]: " + ex.Message);
                if (ex.InnerException != null)
                    _logger.Error("Inner error: " + ex.InnerException.Message);
                _logger.Error("Parameters [" + String.Join(", ", parameters.AllKeys.Select(a => a + "=" + parameters[a])) + "]");
                throw ex;
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
            }
            catch (SerializationException ex)
            {
                _logger.Error("Error [getOriginators]: " + ex.Message);
                if (ex.InnerException != null)
                    _logger.Error("Inner error: " + ex.InnerException.Message);
                _logger.Error("Parameters [" + String.Join(", ", parameters.AllKeys.Select(a => a + "=" + parameters[a])) + "]");
                throw ex;
            }

            foreach (var one in list)
            {
                originators.Add(new Originator(one.Key, one.Value));
            }

            return originators;
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
                _logger.Error("Error [getPhoneBaseItems]: " + ex.Message);
                if (ex.InnerException != null)
                    _logger.Error("Inner error: " + ex.InnerException.Message);
                _logger.Error("Parameters [" + String.Join(", ", parameters.AllKeys.Select(a => a + "=" + parameters[a])) + "]");
                throw ex;
            }
        }

        public List<DeliveryStatus> getDeliveryStatus(BigInteger[] messageId)
        {
            NameValueCollection parameters = new NameValueCollection();
            string messageIdStr = String.Join(",", messageId.Select(p => p.ToString()));
            parameters.Add("state", messageIdStr);

            MemoryStream content = this.getStreamContent("status", parameters);

            List<DeliveryStatus> deliveryStatus = new List<DeliveryStatus>();

            DataContractJsonSerializerSettings settings = new DataContractJsonSerializerSettings();
            settings.UseSimpleDictionaryFormat = true;
            try
            {
                //DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Dictionary<Int64, PhoneBaseItem>), settings);
                //Dictionary<Int64, deliveryStatus> items = serializer.ReadObject(content) as Dictionary<Int64, PhoneBaseItem>;
                //foreach (var one in items)
                //{
                //    PhoneBaseItem item = one.Value;
                //    item.phone = one.Key;
                //    deliveryStatus.Add(item);
                //}

                return deliveryStatus;
            }
            catch (SerializationException ex)
            {
                _logger.Error("Error [getDeliveryStatus]: " + ex.Message);
                if (ex.InnerException != null)
                    _logger.Error("Inner error: " + ex.InnerException.Message);
                _logger.Error("Parameters [" + String.Join(", ", parameters.AllKeys.Select(a => a + "=" + parameters[a])) + "]");
                throw ex;
            }


            //foreach (var one in content)
            //{
            //    deliveryStatus.Add(new DeliveryStatus(one));
            //}

            return deliveryStatus;
        }

        //public List<MessageSendingResult> sendMessage(Int64[] phone, string originator, string text)
        //{
        //    NameValueCollection parameters = new NameValueCollection();
        //    parameters.Add("phone", String.Join(",", phone.Select(p=>p.ToString())));
        //    parameters.Add("sender", originator);
        //    parameters.Add("text", text);

        //    JToken content = this.getContent("send", parameters);

        //    List<MessageSendingResult> messages = new List<MessageSendingResult>();

        //    foreach (var one in content)
        //    {
        //        messages.Add(new MessageSendingResult(one));
        //    }

        //    return messages;
        //}

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
                _logger.Error("Error [checkStopList]: " + ex.Message);
                if (ex.InnerException != null)
                    _logger.Error("Inner error: " + ex.InnerException.Message);
                _logger.Error("Parameters [" + String.Join(", ", parameters.AllKeys.Select(a => a + "=" + parameters[a])) + "]");
                throw ex;
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
				_logger.Error("Error [add2stop]: " + ex.Message);
				if (ex.InnerException != null)
					_logger.Error("Inner error: " + ex.InnerException.Message);
				_logger.Error("Parameters [" + String.Join(", ", parameters.AllKeys.Select(a => a + "=" + parameters[a])) + "]");
				throw ex;
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
				_logger.Error("Error [template]: " + ex.Message);
				if (ex.InnerException != null)
					_logger.Error("Inner error: " + ex.InnerException.Message);
				_logger.Error("Parameters [" + String.Join(", ", parameters.AllKeys.Select(a => a + "=" + parameters[a])) + "]");
				throw ex;
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
				_logger.Error("Error [add_template]: " + ex.Message);
				if (ex.InnerException != null)
					_logger.Error("Inner error: " + ex.InnerException.Message);
				_logger.Error("Parameters [" + String.Join(", ", parameters.AllKeys.Select(a => a + "=" + parameters[a])) + "]");
				throw ex;
			}
		}

		//public List<DailyStats> getDailyStatsByMonth(int year, int month)
		//{
		//	DateTime date = new DateTime(year, month, 1, 0, 0, 0);

		//	NameValueCollection parameters = new NameValueCollection();
		//	parameters.Add("month", date.ToString("yyyy-MM"));

		//	MemoryStream content = this.getStreamContent("stat_by_month", parameters);

		//	DataContractJsonSerializerSettings settings = new DataContractJsonSerializerSettings();
		//	settings.UseSimpleDictionaryFormat = true;
		//	try
		//	{
		//		DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Dictionary<Int64, DailyStats>), settings);
		//		Dictionary<Int64, DailyStats> items = serializer.ReadObject(content) as Dictionary<Int64, DailyStats>;

		//		List<DailyStats> list = new List<DailyStats>();

		//		foreach (var one in items)
		//		{
		//			DailyStats item = one.Value;
		//			//item.id = one.Key;
		//			list.Add(item);
		//		}

		//		return list;
		//	}
		//	catch (SerializationException ex)
		//	{
		//		_logger.Error("Error [stat_by_month]: " + ex.Message);
		//		if (ex.InnerException != null)
		//			_logger.Error("Inner error: " + ex.InnerException.Message);
		//		_logger.Error("Parameters [" + String.Join(", ", parameters.AllKeys.Select(a => a + "=" + parameters[a])) + "]");
		//		throw ex;
		//	}
		//}

        //public List<HLRResponse> makeHLRRequest(Int64[] phone)
        //{
        //    NameValueCollection parameters = new NameValueCollection();
        //    parameters.Add("phone", String.Join(",", phone.Select(p => p.ToString())));

        //    JToken content = this.getContent("hlr", parameters);

        //    List<HLRResponse> HLRResponse = new List<HLRResponse>();
        //    foreach (var one in content)
        //    {
        //        HLRResponse.Add(new HLRResponse(one));
        //    }

        //    return HLRResponse;
        //}

        //public List<HLRStatItem> getHlrStats(string from, string to)
        //{
        //    NameValueCollection parameters = new NameValueCollection();
        //    parameters.Add("from", from);
        //    parameters.Add("to", to);

        //    JToken content = this.getContent("hlr_stat", parameters);

        //    List<HLRStatItem> HLRStatItem = new List<HLRStatItem>();
        //    foreach (var one in content as JObject)
        //    {
        //        HLRStatItem.Add(new HLRStatItem(one.Value));
        //    }

        //    return HLRStatItem;
        //}

        //public Network getNetworkByPhone(Int64 phone)
        //{
        //    NameValueCollection parameters = new NameValueCollection();
        //    parameters.Add("phone", phone.ToString());

        //    JToken content = this.getContent("operator", parameters);

        //    Network network = new Network(content);

        //    return network;
        //}

        //public List<IncomingMessage> getIncomingMessages(string date)
        //{
        //    NameValueCollection parameters = new NameValueCollection();
        //    parameters.Add("date", date);

        //    JToken content = this.getContent("incoming", parameters);

        //    List<IncomingMessage> incomingMessage = new List<IncomingMessage>();
        //    foreach (var one in content)
        //    {
        //        incomingMessage.Add(new IncomingMessage(one));
        //    }

        //    return incomingMessage;
        //}
    }
}
