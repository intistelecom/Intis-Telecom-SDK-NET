using System.Net;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Specialized;
using System.Web.Script.Serialization;
using System.IO;
using System.Collections.Generic;
using System.Web;
using Intis.SDK.Exceptions;

namespace Intis.SDK
{
    public abstract class AClient
    {
        protected string Login;
        protected string ApiKey;
        protected string ApiHost;

        public MemoryStream GetStreamContent(string scriptName, NameValueCollection parameters)
        {
            var result = GetContent(scriptName, parameters);

            var byteArray = Encoding.UTF8.GetBytes(result);
            var stream = new MemoryStream(byteArray);

            return stream;
        }

        public string GetContent(string scriptName, NameValueCollection parameters)
        {
            var allParameters = GetParameters(parameters);
            var url = ApiHost + scriptName + ".php";
            var result = getContentFromApi(url, allParameters);
            checkException(result);

            return result;
        }

        private string GetTimestamp() {
            var client = new WebClient();
            var timestamp = client.DownloadString(ApiHost + "timestamp.php");
            return timestamp;
        }

        private NameValueCollection GetBaseParameters()
        {
            var parameters = new NameValueCollection
            {
                {"login", Login},
                {"timestamp", GetTimestamp()},
                {"return", "json"}
            };
            return parameters;
        }

        private NameValueCollection GetParameters(NameValueCollection more)
        {
            var parameters = GetBaseParameters();

            if (more.Count > 0) {
				foreach (var key in more.AllKeys) // <-- No duplicates returned.
				{
					parameters.Add(key, more[key]);
				}
            }
            var sig = GetSignature(parameters);
            parameters.Add("signature", sig);

            return parameters;
        }

        private string GetSignature(NameValueCollection parameters)
        {
            var str = parameters.AllKeys.OrderBy(k => k).Aggregate(string.Empty, (current, item) => current + parameters[item]);
            str = str + ApiKey;

            return GetMd5Hash(str);
        }

        private static string GetMd5Hash(string str){
            var md5Hasher = MD5.Create();
            var data = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(str));
            var sBuilder = new StringBuilder();

            foreach (var t in data)
            {
                sBuilder.Append(t.ToString("x2"));
            }

            return sBuilder.ToString();
        }

		private void checkException(string result)
        {
            if (!result.Any())
            {
                throw new SdkException(0);
            }

		    if (result.Substring(0, 8) != "{\"error\"") 
                return;
		    var serializer = new JavaScriptSerializer();
		    var list = serializer.Deserialize<Dictionary<string, int>>(result);

		    throw new SdkException(list.First().Value);
        }

        private string getContentFromApi(string url, NameValueCollection allParameters)
        {
            var encodeParameters = new NameValueCollection();

            for (var i = 0; i <= allParameters.Count - 1; i++)
            {
                var param = HttpUtility.UrlEncode(allParameters.Get(i));
                if(param != null)
                    encodeParameters.Add(allParameters.GetKey(i), param);
            }

            var client = new WebClient
            {
                QueryString = encodeParameters, 
                Encoding = Encoding.UTF8
            };

            var result = client.DownloadString(url);

            return result;
        }
    }
}
