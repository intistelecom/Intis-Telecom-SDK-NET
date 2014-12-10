using System.Net;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Specialized;
using Newtonsoft.Json.Linq;

namespace Intis.SDK
{
    public abstract class AClient
    {
        protected string login;
        protected string apiKey;
        protected string apiHost;

		public JToken getContent(string scriptName, NameValueCollection parameters)
        {
            NameValueCollection allParameters = this.getParameters(parameters);
            string url = apiHost + scriptName + ".php";
			JToken result = this.getContentFromApi(url, allParameters);
            this.checkException(result);

            return result;
        }

        private string getTimestamp() {
            WebClient client = new WebClient();
            string timestamp = client.DownloadString(apiHost + "timestamp.php");
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

            return this.GetMd5Hash(str);
        }

        private string GetMd5Hash(string str){
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(str));
            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

		private void checkException(JToken result)
        {
		    if(result.Count() == 0)
			    throw new SDKException(0);
			if (result.First.Path == "error")
				throw new SDKException((int)result.First);
        }

		private JToken getContentFromApi(string url, NameValueCollection allParameters)
        {
            WebClient client = new WebClient();
            client.QueryString = allParameters;
            string result = client.DownloadString(url);

            if (result.Length == 0)
				return new JConstructor();


			JToken data = JConstructor.Parse(result);
			
            return data;
        }
    }
}
