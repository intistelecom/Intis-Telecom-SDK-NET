using System.Collections.Specialized;

namespace Intis.SDK
{
	public interface IApiConnector
	{
		/// <summary>
		///Getting data from API.
		/// </summary>
		/// <returns>connector</returns>
		string GetContentFromApi(string link, NameValueCollection allParameters);

		/// <summary>
		///Getting timestamp from API.
		/// </summary>
		/// <returns>connector</returns>
		string GetTimestampFromApi(string link);
	}
}