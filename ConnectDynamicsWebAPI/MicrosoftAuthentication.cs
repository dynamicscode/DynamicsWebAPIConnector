using System;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConnectDynamicsWebAPI
{
    public class MicrosoftAuthentication
    {
        string tenantId, tokenUrl, grantType, clientId, clientSecret, resourceUrl;
        HttpClient httpClient;

        public MicrosoftAuthentication()
        {
            tenantId = ConfigurationManager.AppSettings["TenantId"];
            tokenUrl = ConfigurationManager.AppSettings["TokenUrl"].Replace("@TenantId", tenantId);
            grantType = ConfigurationManager.AppSettings["GrantType"];
            clientId = ConfigurationManager.AppSettings["ClientId"];
            clientSecret = ConfigurationManager.AppSettings["ClientSecret"];
            resourceUrl = ConfigurationManager.AppSettings["ResourceUrl"];
        }
        public async Task<string> GetToken()
        {
            var data = new MultipartFormDataContent();
            data.Add(new StringContent(grantType), "grant_type");
            data.Add(new StringContent(clientId), "client_id");
            data.Add(new StringContent(clientSecret), "client_secret");
            data.Add(new StringContent(resourceUrl), "resource");

            var httpRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(tokenUrl),
                Content = data
            };

            httpClient = new HttpClient();

            var response = await httpClient.SendAsync(httpRequest);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return result;
            }
            else

                return string.Empty;
        }
    }
}
