using System;

namespace FrostSharp
{
    public class Configuration
    {
        public string Host { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public int Timeout { get; private set; }

        public Configuration(string Host, string Email, string Password, int Timeout) 
        {
            this.Host = Host;
            this.Email = Email;
            this.Password = Password;
            this.Timeout = Timeout;
        }

        public Configuration(string Host, string Email, string Password) : this(Host, Email, Password, 10) { }

        public Configuration(string Host, int Timeout) : this(Host, "", "") { }

        public Configuration(string Host) : this(Host, 10) { }
    }
}
