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

using Intis.SDK;
using Intis.SDK.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
	[TestClass]
	public class TemplatesTest
	{
		const string Login = "your api login";
		const string ApiKey = "your api key here";
		const string ApiHost = "http://api.host.com/get/";

		[TestMethod]
		public void TestGetTemplates()
		{

			IApiConnector connector = new LocalApiConnector(getData());

			var client = new IntisClient(Login, ApiKey, ApiHost, connector);

			var templates = client.GetTemplates();
			foreach (var one in templates)
			{
				var id = one.Id;
				var title = one.Title;
				var template = one.template;
				var createdAt = one.CreatedAt;
			}

			Assert.IsNotNull(templates);
		}

		[TestMethod]
		[ExpectedException(typeof(TemplateException))]
		public void TestGetTemplatesException()
		{
			IApiConnector connector = new LocalApiConnector(getErrorData());

			var client = new IntisClient(Login, ApiKey, ApiHost, connector);

			client.GetTemplates();
		}

		private string getData()
		{
			return "{\"25583\":{\"name\":\"newtemplate\",\"template\":\"Hello! #first-name# #last-name#! Your amount is #note1#\",\"up_time\":\"2015-03-31 15:22:50\"},\"25586\":{\"name\":\"test1\",\"template\":\"template for test1\",\"up_time\":\"2015-07-29 15:37:47\"},\"25582\":{\"name\":\"vnb cv\",\"template\":\"test\",\"up_time\":\"2015-03-30 17:34:39\"}}";
		}

		private string getErrorData()
		{
			return "{\"error\":4}";
		}
	}
}
