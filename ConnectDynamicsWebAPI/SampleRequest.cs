using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConnectDynamicsWebAPI
{
    public class SampleRequest
    {
        public async Task<string> Execute(string token)
        {
            var httpRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{ConfigurationManager.AppSettings["ResourceUrl"]}/api/data/v9.1/contacts")
            };

            httpRequest.Headers.Add("Authorization", $"Bearer {token}");
            var httpClient = new HttpClient();

            var response = await httpClient.SendAsync(httpRequest);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return string.Empty;
        }
    }
}
