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

using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Web;

namespace Intis.SDK
{
	/// <summary>
	/// Class HttpApiConnector
	/// HTTP API data connector implementation API data connector
	/// </summary>
	public class HttpApiConnector : IApiConnector
	{
		/// <summary>
		/// Getting data from API
		/// </summary>
		/// <param name="url">API address</param>
		/// <param name="allParameters">parameters</param>
		/// <returns>data as an string</returns>
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

		/// <summary>
		/// Getting timestamp from API
		/// </summary>
		/// <param name="url">API address</param>
		/// <returns>timestamp as an string</returns>
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