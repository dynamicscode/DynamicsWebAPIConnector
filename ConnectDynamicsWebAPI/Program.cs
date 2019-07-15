using ConnectDynamicsWebAPI.Model;
using Newtonsoft.Json;
using System;

namespace ConnectDynamicsWebAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            var auth = new MicrosoftAuthentication();
            var result = auth.GetToken().Result;

            var token = JsonConvert.DeserializeObject<TokenResponse>(result);

            Console.WriteLine(token.AccessToken);

            var sample = new SampleRequest();

            var contacts = sample.Execute(token.AccessToken);
            Console.WriteLine(contacts.Result);

            Console.ReadKey();
        }
    }
}
