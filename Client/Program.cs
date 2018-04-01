using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdentityModel.Client;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace Client
{
    class Program
    {
        static void Main(string[] args) => MainTask().GetAwaiter().GetResult();
        

        private static async Task MainTask()
        {
            var disco=await DiscoveryClient.GetAsync("http://localhost:5000");
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return;
            }

            //request the token
            var tokenClient = new TokenClient(disco.TokenEndpoint, "Guru", "GuruKey");
            var tokenResponse = await tokenClient.RequestClientCredentialsAsync("First API");

            
            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;
            }

            //Print the Response
            Console.WriteLine(tokenResponse.Json+"\n\n");

            //Call the API
            var callClient = new HttpClient();
            callClient.SetBearerToken(tokenResponse.AccessToken);

            var response = await callClient.GetAsync("http://localhost:5001/Identity/GetUserInfo");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode); 
                return;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync(); //Get the Content from the API
                Console.WriteLine(JArray.Parse(content));
            }


        }
    }
}
