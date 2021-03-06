﻿// The MIT License (MIT)
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
	public class DeliveryStatusTest
	{
		const string Login = "your api login";
		const string ApiKey = "your api key here";
		const string ApiHost = "http://api.host.com/get/";

		[TestMethod]
		public void TestGetDeliveryStatus()
		{
			IApiConnector connector = new LocalApiConnector(getData());

			var client = new IntisClient(Login, ApiKey, ApiHost, connector);
			var messageId = new[] { "4196226820248326060001" };

			var status = client.GetDeliveryStatus(messageId);
			foreach (var one in status)
			{
				var meassageId = one.MessageId;
				var messageStatue = one.MessageStatus;
				var createdAt = one.CreatedAt;
			}

			Assert.IsNotNull(status);
		}

		[TestMethod]
		[ExpectedException(typeof(DeliveryStatusException))]
		public void TestGetDeliveryStatusException()
		{
			IApiConnector connector = new LocalApiConnector(getErrorData());

			var client = new IntisClient(Login, ApiKey, ApiHost, connector);

			var messageId = new[] { "4196226820248326060001" };

			client.GetDeliveryStatus(messageId);
		}

		private string getData()
		{
			return "{\"4385937961543210880001\":{\"status\":\"deliver\", \"time\":\"2014-10-05\"},\"4385937961543210880002\":{\"status\":\"not_deliver\", \"time\":\"2014-10-01\"}}";
		}

		private string getErrorData()
		{
			return "{\"error\":4}";
		}
	}
}
