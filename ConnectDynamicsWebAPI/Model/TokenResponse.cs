using Newtonsoft.Json;

namespace ConnectDynamicsWebAPI.Model
{
    public class TokenResponse
    {
        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
    }
}
