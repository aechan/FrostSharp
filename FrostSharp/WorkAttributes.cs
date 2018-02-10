using System;

public class WorkAttributes 
{
    public string Name { get; private set; }
    public DateTime DatePublished { get; private set; }
    public DateTime DateCreated { get; private set; }
    public string Author { get; private set; }
    public string Tags { get; private set; }
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
}