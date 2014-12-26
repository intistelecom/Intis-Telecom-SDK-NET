using System.Runtime.Serialization;

namespace Intis.SDK.Entity
{
    [DataContract]
    public class Network
    {
        [DataMember(Name = "operator")]
        private string title {get; set;}


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
