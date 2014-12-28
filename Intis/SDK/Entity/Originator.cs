using System.Runtime.Serialization;

namespace Intis.SDK.Entity
{
    [DataContract]
    public class Originator
    {
        /// <summary>
        /// Sender name
        /// </summary>
        /// <returns>string</returns>
        public string Name {get; set;}

        private string StateText { get; set; }

        /// <summary>
        /// Sender status
        /// </summary>
        /// <returns>integer</returns>
        public int? State {
            get { return OriginatorState.Parse(StateText); }
        }

        public Originator(string originator, string state)
        {
            Name = originator;
            StateText = state;
        }
    }
}
