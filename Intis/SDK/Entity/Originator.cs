using System.Runtime.Serialization;

namespace Intis.SDK.Entity
{
    [DataContract]
    public class Originator
    {
        private string originator {get; set;}
        private string state { get; set; }

        public Originator(string originator, string state)
        {
            this.originator = originator;
            this.state = state;
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
