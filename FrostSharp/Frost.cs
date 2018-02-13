using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FrostSharp
{
    public class Frost 
    {
        private HttpClient client;
        private Configuration Config;

        /// <summary>
        /// Constructs a new Frost client with the following parameters.
        /// </summary>
        /// <param name="APIToken">Your Frost API token (https://frost.po.et)</param>
        /// <param name="Config">A Frost configuration object.</param>
        /// <param name="Logging">If true, all requests are logged to stdout.</param>
        public Frost(string APIToken, Configuration Config, bool Logging) 
        {
            this.Config = Config;

            if(Logging)
                this.client = new HttpClient(new FrostSharp.Utils.LoggingHandler(new HttpClientHandler()));
            else
                this.client = new HttpClient();

            client.DefaultRequestHeaders.Add("token", APIToken);
        }

        /// <summary>
        /// Takes a WorkAttributes class and posts it on the po.et network.
        /// </summary>
        /// <param name="Work">A WorkAttributes containing the data for your work.</param>
        /// <returns>The ID of the created work.</returns>
        public async Task<string> CreateWork(WorkAttributes Work) 
        {
            if(Work == null) throw new ArgumentNullException();
            
            string targetURI = Config.Host + Path.WORKS;
            var res = await client.PostAsync(targetURI, new StringContent(Work.ToJSON(), System.Text.Encoding.UTF8, "application/json"));
            var result = await res.Content.ReadAsStringAsync();

            if(res.IsSuccessStatusCode) 
            {
                var workIDType = new { workId = "" };
                return Newtonsoft.Json.JsonConvert.DeserializeAnonymousType(result, workIDType).workId;
            }
            else
            {
                throw new HttpRequestException("Bad Request: " + result);
            }
        }

        /// <summary>
        /// Get a work by it's WorkID, this can be any work on the po.et network.
        /// </summary>
        /// <param name="WorkId">The ID of the work you're looking for.</param>
        /// <returns>The WorkAttribute representation of the work.</returns>
        public async Task<WorkAttributes> GetWork(string WorkId)
        {
            string targetURI = Config.Host + Path.WORKS + "/" + WorkId;
            var res = await client.GetAsync(targetURI);
            var result = await res.Content.ReadAsStringAsync();

            if(res.IsSuccessStatusCode)
            {
                WorkAttributes work = WorkAttributes.FromJSON(result);
                return work;
            }
            else
            {
                throw new HttpRequestException("Bad Request: " + result);
            }
        }

        /// <summary>
        /// Gets all the works associated with this API key.
        /// </summary>
        /// <returns>A List of WorkAttributes</returns>
        public async Task<List<WorkAttributes>> GetAllWorks()
        {
            string targetURI = Config.Host + Path.WORKS;
            var res = await client.GetAsync(targetURI);
            var result = await res.Content.ReadAsStringAsync();

            if(res.IsSuccessStatusCode)
            {
                List<WorkAttributes> works = WorkAttributes.ListFromJSON(result);
                return works;
            }
            else
            {
                throw new HttpRequestException("Bad Request: " + result);
            }

        }
        
    }
}