using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FrostSharp
{
    public class WorkAttributes 
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; private set; }

        [JsonProperty(PropertyName = "datePublished")]
        public string DatePublished { get; private set; }

        [JsonProperty(PropertyName = "dateCreated")]
        public string DateCreated { get; private set; }

        [JsonProperty(PropertyName = "author")]
        public string Author { get; private set; }

        [JsonProperty(PropertyName = "tags")]
        public string Tags { get; private set; }

        [JsonProperty(PropertyName = "content")]
        public string Content { get; private set; }

        public WorkAttributes(string Name, DateTime DatePublished, DateTime DateCreated, string Author, string Tags, string Content) 
        {
            this.Name = Name;
            this.DatePublished = DatePublished.ToString("yyyy-MM-ddTHH:mm:sszzz");
            this.DateCreated = DateCreated.ToString("yyyy-MM-ddTHH:mm:sszzz");
            this.Author = Author;
            this.Tags = Tags;
            this.Content = Content;
        }

        public WorkAttributes(string Name, DateTime DatePublished, DateTime DateCreated, string Author, string Content) : this(Name, DatePublished, DateCreated, Author, "", Content) { }
    
        public WorkAttributes() : this("", DateTime.UtcNow, DateTime.UtcNow, "", "", "") { }


        public string ToJSON()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static WorkAttributes FromJSON(string json)
        {
            return JsonConvert.DeserializeObject<WorkAttributes>(json);
        }

        public static List<WorkAttributes> ListFromJSON(string json)
        {
            return JsonConvert.DeserializeObject<List<WorkAttributes>>(json);
        }
    }
}