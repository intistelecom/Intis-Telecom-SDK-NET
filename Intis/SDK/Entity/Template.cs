using Newtonsoft.Json.Linq;
using System;

namespace Intis.SDK.Entity
{
    public class Template
    {
        private Int64 id { get; set; }
        private string title { get; set; }
        private string template { get; set; }
        private string createdAt { get; set; }

        public Template(JToken obj)
        {
		    JObject template = obj.First as JObject;
			this.id = Int64.Parse(obj.Path);
			this.title = (string)template.GetValue("name");
			this.template = (string)template.GetValue("template");
			this.createdAt = (string)template.GetValue("up_time");
        }

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
