using System.Net;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Specialized;
using Newtonsoft.Json.Linq;
using log4net;
using System.Web.Script.Serialization;
using Intis.SDK.Entity;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Collections.Generic;
using System.Web;

namespace Intis.SDK
{
    public abstract class AClient
    {
        protected string login;
        protected string apiKey;
        protected string apiHost;
        public static readonly ILog _logger = LogManager.GetLogger("IntisSDK");

        public MemoryStream getStreamContent(string scriptName, NameValueCollection parameters)
        {
            string result = getContent(scriptName, parameters);

            byte[] byteArray = Encoding.UTF8.GetBytes(result);
            MemoryStream stream = new MemoryStream(byteArray);

            return stream;
        }

        public string getContent(string scriptName, NameValueCollection parameters)
        {
            NameValueCollection allParameters = this.getParameters(parameters);
            string url = apiHost + scriptName + ".php";
            string result = this.getContentFromApi(url, allParameters);
            //this.checkException(result);

            return result;
        }

        private string getTimestamp() {
            WebClient client = new WebClient();
            string timestamp = client.DownloadString(apiHost + "timestamp.php");
            _logger.Info("Get timestamp: [" + timestamp + "]");
            return timestamp;
        }

        private NameValueCollection getBaseParameters()
        {
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("login", login);
            parameters.Add("timestamp", this.getTimestamp());
            parameters.Add("return", "json");
            return parameters;
        }

        private NameValueCollection getParameters(NameValueCollection more)
        {
            NameValueCollection parameters = this.getBaseParameters();

            if (more.Count > 0) {
				foreach (string key in more.AllKeys) // <-- No duplicates returned.
				{
					parameters.Add(key, more[key]);
				}
            }
            string sig = this.GetSignature(parameters);
            _logger.Info("Signature: [" + sig + "]");
            parameters.Add("signature", sig);

            return parameters;
        }

        private string GetSignature(NameValueCollection parameters)
        {
            string str = string.Empty;
            foreach (var item in parameters.AllKeys.OrderBy(k => k)){
                str = str + parameters[item];
            }
            str = str + apiKey;
            _logger.Info("String for the calculation of the signature: [" + str + "]");

            return this.GetMd5Hash(str);
        }

        private string GetMd5Hash(string str){
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(str));
            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

		private void checkException(JToken result)
        {
            if (result.Count() == 0)
            {
                _logger.Error("Empty result: [" + result + "]. SDKException(0)");
                throw new SDKException(0);
            }
            if (result.First.Path == "error")
            {
                _logger.Error("Error: [" + result + "]. SDKException(" + (int)result.First + ")");
                throw new SDKException((int)result.First);
            }
        }

        private string getContentFromApi(string url, NameValueCollection allParameters)
        {
            NameValueCollection encodeParameters = new NameValueCollection();

            for (int i = 0; i <= allParameters.Count - 1; i++)
            {
                encodeParameters.Add(allParameters.GetKey(i), HttpUtility.UrlEncode(allParameters.Get(i)));
            }

            WebClient client = new WebClient();
            client.QueryString = encodeParameters;
            client.Encoding = Encoding.UTF8;

            string result = client.DownloadString(url);

            return result;
        }
    }
}
