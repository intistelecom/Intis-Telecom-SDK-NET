using Newtonsoft.Json.Linq;

namespace Intis.SDK.Entity
{
    public class Originator
    {
        private string originator {get; set;}
        private string state { get; set; }

		public Originator(JToken obj)
        {
			this.originator = obj.Path;
			this.state = obj.First.ToString();
        }

        /// <summary>
        /// Sender name
        /// </summary>
        /// <returns>string</returns>
        public string getOriginator()
        {
            return this.originator;
        }

        /// <summary>
        /// Sender status
        /// </summary>
        /// <returns>integer</returns>
        public int? getState()
        {
            return OriginatorState.parse(this.state);
        }
    }
}
