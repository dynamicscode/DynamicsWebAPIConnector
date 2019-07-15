using Newtonsoft.Json;
using System;

namespace ConnectDynamicsWebAPI.Model
{

    public class Contact
    {
        [JsonProperty("contactid")]
        public Guid Id { get; set; }

        [JsonProperty("firstname")]
        public string FirstName { get; set; }
    }
}
