using Newtonsoft.Json.Linq;

namespace Intis.SDK.Entity
{
    public class Network
    {
        private string title {get; set;}

        public Network(JToken obj) {
			this.title = (string)obj["operator"];
        }

        /// <summary>
        /// Operator name
        /// </summary>
        /// <returns>string</returns>
        public string getTitle()
        {
            return this.title;
        }
    }
}
