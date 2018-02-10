using System;
using System.Net.Http;
using System.Threading.Tasks;


namespace FrostSharp
{
    public class Frost 
    {
        private HttpClient http;
        private Configuration Config;

        public Frost(Configuration Config) 
        {
            this.Config = Config;
            this.http = new HttpClient();
        }

        public async Task<string> CreateWork(string APIToken, WorkAttributes Work) 
        {
            var res = await http.PostAsync(Config.Host + Path.WORKS, new StringContent(Work.ToJSON()));
            return res.Content.ToString();
        }

        public async Task<WorkAttributes> GetWork(string APIToken, string WorkId)
        {
            var res = await http.GetAsync(Config.Host + Path.WORKS + "/" + WorkId);
            return WorkAttributes.FromJSON(res.Content.ToString());
        }
        
    }
}