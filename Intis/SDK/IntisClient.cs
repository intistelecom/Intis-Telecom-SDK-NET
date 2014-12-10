using System;
using System.Collections.Generic;
using System.Linq;
using Intis.SDK.Entity;
using System.Collections.Specialized;
using Newtonsoft.Json.Linq;
using System.Numerics;

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
			JToken content = this.getContent("balance", parameters);
            Balance balance = new Balance(content);

            return balance;
        }

        public List<PhoneBase> getPhoneBases() {
            NameValueCollection parameters = new NameValueCollection();
			JToken content = this.getContent("base", parameters);

            List<PhoneBase> phoneBases = new List<PhoneBase>();

			foreach (var one in content)
			{
				phoneBases.Add(new PhoneBase(one));
			}

            return phoneBases;
        }

        public List<Originator> getOriginators()
        {
            NameValueCollection parameters = new NameValueCollection();
			JToken content = this.getContent("senders", parameters);

            List<Originator> originators = new List<Originator>();
			foreach (var one in content)
			{
				originators.Add(new Originator(one));
			}

            return originators;
        }

        public List<PhoneBaseItem> getPhoneBaseItems(int baseId, int page = 1)
        {
            NameValueCollection parameters = new NameValueCollection();
			string baseIdStr = baseId.ToString();
			string pageStr = page.ToString();

			parameters.Add("base", baseIdStr);
			parameters.Add("page", pageStr);

			JToken content = this.getContent("phone", parameters);

            List<PhoneBaseItem> phoneBaseItem = new List<PhoneBaseItem>();

			foreach (var one in content)
			{
				phoneBaseItem.Add(new PhoneBaseItem(one));
			}

            return phoneBaseItem;
        }

		public List<DeliveryStatus> getDeliveryStatus(BigInteger[] messageId)
        {
            NameValueCollection parameters = new NameValueCollection();
			string messageIdStr = String.Join(",", messageId.Select(p=>p.ToString()));
			parameters.Add("state", messageIdStr);

			JToken content = this.getContent("status", parameters);

            List<DeliveryStatus> deliveryStatus = new List<DeliveryStatus>();
			foreach (var one in content)
			{
				deliveryStatus.Add(new DeliveryStatus(one));
			}

            return deliveryStatus;
        }

        public List<MessageSendingResult> sendMessage(Int64[] phone, string originator, string text)
        {
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("phone", String.Join(",", phone.Select(p=>p.ToString())));
            parameters.Add("sender", originator);
            parameters.Add("text", text);

			JToken content = this.getContent("send", parameters);

            List<MessageSendingResult> messages = new List<MessageSendingResult>();

			foreach (var one in content)
			{
				messages.Add(new MessageSendingResult(one));
			}

            return messages;
        }

        public StopList checkStopList(Int64 phone)
        {
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("phone", phone.ToString());

			JToken content = this.getContent("find_on_stop", parameters);

			StopList messages = new StopList(content);

            return messages;
        }

		public Int64 addToStopList(Int64 phone)
        {
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("phone", phone.ToString());

			JToken content = this.getContent("add2stop", parameters);

			JObject id = content as JObject;
			var idt = (string)id.GetValue("id");

			return Int64.Parse(idt);
        }

        public List<Template> getTemplates()
        {
            NameValueCollection parameters = new NameValueCollection();

			JToken content = this.getContent("template", parameters);

            List<Template> template = new List<Template>();
			foreach (var one in content)
			{
				template.Add(new Template(one));
			}

            return template;
        }

        public Int64 addTemplate(string title, string template)
        {
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("name", title);
            parameters.Add("text", template);

			JToken content = this.getContent("add_template", parameters);

			JObject id = content as JObject;
			var idt = (string)id.GetValue("id");

			return Int64.Parse(idt);
        }

        public List<DailyStats> getDailyStatsByMonth(int year, int month)
        {
            DateTime date = new DateTime(year, month, 1, 0, 0, 0);

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("month", date.ToString("yyyy-MM"));

			JToken content = this.getContent("stat_by_month", parameters);

            List<DailyStats> dailyStats = new List<DailyStats>();
			foreach (var one in content)
			{
				dailyStats.Add(new DailyStats(one));
			}

            return dailyStats;
        }

        public List<HLRResponse> makeHLRRequest(Int64[] phone)
        {
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("phone", String.Join(",", phone.Select(p => p.ToString())));

			JToken content = this.getContent("hlr", parameters);

            List<HLRResponse> HLRResponse = new List<HLRResponse>();
			foreach (var one in content)
			{
				HLRResponse.Add(new HLRResponse(one));
			}

            return HLRResponse;
        }

        public List<HLRStatItem> getHlrStats(string from, string to)
        {
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("from", from);
            parameters.Add("to", to);

			JToken content = this.getContent("hlr_stat", parameters);

            List<HLRStatItem> HLRStatItem = new List<HLRStatItem>();
			foreach (var one in content as JObject)
			{
				HLRStatItem.Add(new HLRStatItem(one.Value));
			}

            return HLRStatItem;
        }

        public Network getNetworkByPhone(Int64 phone)
        {
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("phone", phone.ToString());

			JToken content = this.getContent("operator", parameters);

			Network network = new Network(content);

            return network;
        }

        public List<IncomingMessage> getIncomingMessages(string date)
        {
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("date", date);

			JToken content = this.getContent("incoming", parameters);

            List<IncomingMessage> incomingMessage = new List<IncomingMessage>();
			foreach (var one in content)
			{
				incomingMessage.Add(new IncomingMessage(one));
			}

            return incomingMessage;
        }
    }
}
