using System;
using System.Runtime.Serialization;

namespace Intis.SDK.Entity
{
    [DataContract]
    public class Template
    {
        public Int64 id { get; set; }

		[DataMember(Name = "name")]
        private string title { get; set; }

		[DataMember(Name = "template")]
        private string template { get; set; }

		[DataMember(Name = "up_time")]
        private string createdAt { get; set; }


        /// <summary>
        /// Template ID
        /// </summary>
        /// <returns>integer</returns>
        public Int64 getId()
        {
            return this.id;
        }

        /// <summary>
        /// Template name
        /// </summary>
        /// <returns>string</returns>
        public string getTitle()
        {
            return this.title;
        }

        /// <summary>
        /// Text of template
        /// </summary>
        /// <returns>string</returns>
        public string getTemplate()
        {
            return this.template;
        }

        /// <summary>
        /// Time of template creating
        /// </summary>
        /// <returns>string</returns>
        public string getCreatedAt()
        {
            return this.createdAt;
        }
    }
}
