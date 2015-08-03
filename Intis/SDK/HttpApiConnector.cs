using System.Collections.Specialized;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;

namespace Intis.SDK
{
	public class HttpApiConnector : IApiConnector
	{
		public string GetContentFromApi(string url, NameValueCollection allParameters)
		{
			var encodeParameters = new NameValueCollection();

			for (var i = 0; i <= allParameters.Count - 1; i++)
			{
				var param = HttpUtility.UrlEncode(allParameters.Get(i));
				if (param != null)
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

		public string GetTimestampFromApi(string url)
		{
			var client = new WebClient
			{
				Encoding = Encoding.UTF8
			};

			var result = client.DownloadString(url);

			return result;
		}

	}
}