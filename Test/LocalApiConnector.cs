using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intis.SDK;

namespace Test
{
	class LocalApiConnector : IApiConnector
	{
		private string _data;

		public LocalApiConnector(string data){
			_data = data;
		}

		public string GetContentFromApi(string link, NameValueCollection allParameters)
		{
			return _data;
		}

		public string GetTimestampFromApi(string link){
			return String.Empty;
		}
	}
}
