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

using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Specialized;
using System.Web.Script.Serialization;
using System.IO;
using System.Collections.Generic;
using Intis.SDK.Exceptions;

namespace Intis.SDK
{
	/// <summary>
	/// Class AClient
	/// The main class for working with API
	/// </summary>
    public abstract class AClient
    {
		/// <summary>
		/// User´s login
		/// </summary>
        protected string Login;

		/// <summary>
		/// SDK key
		/// </summary>
        protected string ApiKey;

		/// <summary>
		/// SDK address
		/// </summary>
        protected string ApiHost;

		/// <summary>
		/// API data connector
		/// </summary>
		private IApiConnector ApiConnector;

		protected AClient(IApiConnector apiConnector)
		{
			ApiConnector = apiConnector ?? new HttpApiConnector();
		}

		/// <summary>
		///  Getting content using parameters and name of API script
		/// </summary>
		/// <param name="scriptName">Name of API script</param>
		/// <param name="parameters">parameters</param>
		/// <returns>returns the data as an stream</returns>
		protected MemoryStream GetStreamContent(string scriptName, NameValueCollection parameters)
        {
            var result = GetContent(scriptName, parameters);

            var byteArray = Encoding.UTF8.GetBytes(result);
            var stream = new MemoryStream(byteArray);

            return stream;
        }

		/// <summary>
		/// Getting content using parameters and name of API script
		/// </summary>
		/// <param name="scriptName">Name of API script</param>
		/// <param name="parameters">parameters</param>
		/// <returns>returns the data as an string</returns>
		protected string GetContent(string scriptName, NameValueCollection parameters)
        {
            var allParameters = GetParameters(parameters);
            var url = ApiHost + scriptName + ".php";
			var result = ApiConnector.GetContentFromApi(url, allParameters);
            checkException(result);

            return result;
        }

		/// <summary>
		/// Getting time in UNIX format from the file timestamp.php in API
		/// </summary>
		/// <returns>timestamp as an string</returns>
        private string GetTimestamp()
        {
	        string url = ApiHost + "timestamp.php";
			var timestamp = ApiConnector.GetTimestampFromApi(url);

            return timestamp;
        }

		/// <summary>
		/// Getting basic API parameters 
		/// </summary>
		/// <returns>basic API parameters</returns>
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

		/// <summary>
		/// Getting additional parameters for API.
		/// It creates an array with additional parameters and complements an array with a signature key.
		/// </summary>
		/// <param name="more">additional parameters</param>
		/// <returns>parameters</returns>
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

		/// <summary>
		/// Getting signatures by incoming parameters
		/// </summary>
		/// <param name="parameters">all parameters</param>
		/// <returns>signature</returns>
        private string GetSignature(NameValueCollection parameters)
        {
            var str = parameters.AllKeys.OrderBy(k => k).Aggregate(string.Empty, (current, item) => current + parameters[item]);
            str = str + ApiKey;

            return GetMd5Hash(str);
        }

		/// <summary>
		/// Generating Hash from String
		/// </summary>
		/// <param name="str">line parameters</param>
		/// <returns>hash</returns>
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

		/// <summary>
		/// Testing for special exceptions and error output
		/// </summary>
		/// <param name="result">data as an string</param>
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
    }
}
