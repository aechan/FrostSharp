using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace FrostSharp
{
    [DataContract]
    public class WorkAttributes 
    {
        [DataMember]
        public string Name { get; private set; }

        [DataMember]
        public DateTime DatePublished { get; private set; }

        [DataMember]
        public DateTime DateCreated { get; private set; }

        [DataMember]
        public string Author { get; private set; }

        [DataMember]
        public string Tags { get; private set; }

        [DataMember]
        public string Content { get; private set; }

        public WorkAttributes(string Name, DateTime DatePublished, DateTime DateCreated, string Author, string Tags, string Content) 
        {
            this.Name = Name;
            this.DatePublished = DatePublished;
            this.DateCreated = DateCreated;
            this.Author = Author;
            this.Tags = Tags;
            this.Content = Content;
        }

        public WorkAttributes(string Name, DateTime DatePublished, DateTime DateCreated, string Author, string Content) : this(Name, DatePublished, DateCreated, Author, "", Content) { }
    
        public string ToJSON()
        {
            MemoryStream ms = new MemoryStream();

            var serializer = new DataContractJsonSerializer(typeof(WorkAttributes));
            serializer.WriteObject(ms, this);
            byte[] json = ms.ToArray();
            ms.Close();
            return Encoding.UTF8.GetString(json, 0, json.Length);
        }

        public static WorkAttributes FromJSON(string json)
        {
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(WorkAttributes));
            WorkAttributes work = ser.ReadObject(ms) as WorkAttributes;
            ms.Close();
            return work;
        }
    }
}