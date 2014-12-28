using System;
using System.Runtime.Serialization;

namespace Intis.SDK.Entity
{
    [DataContract]
    public class Template
    {
        /// <summary>
        /// Template ID
        /// </summary>
        /// <returns>integer</returns>
        public Int64 Id { get; set; }

        /// <summary>
        /// Template name
        /// </summary>
        /// <returns>string</returns>
		[DataMember(Name = "name")]
        public string Title { get; set; }

        /// <summary>
        /// Text of template
        /// </summary>
        /// <returns>string</returns>
		[DataMember(Name = "template")]
        public string template { get; set; }

        /// <summary>
        /// Time of template creating
        /// </summary>
        /// <returns>string</returns>
		[DataMember(Name = "up_time")]
        public string CreatedAt { get; set; }
    }
}
