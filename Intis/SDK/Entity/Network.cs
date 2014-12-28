using System.Runtime.Serialization;

namespace Intis.SDK.Entity
{
    [DataContract]
    public class Network
    {
        /// <summary>
        /// Operator name
        /// </summary>
        /// <returns>string</returns>
        [DataMember(Name = "operator")]
        public string Title {get; set;}
    }
}
