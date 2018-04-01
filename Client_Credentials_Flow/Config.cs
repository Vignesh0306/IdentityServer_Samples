using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;

namespace Client_Credentials_Flow
{
    public class Config
    {
        //Method to Load the List of Resources
        public static IEnumerable<ApiResource> GetResources()
        {
            return new List<ApiResource>()
            {
                new ApiResource("First API","First API ")
            };

        }

        //Method to Load the List of Clients
        public static IEnumerable<Client> StoreClients()
        {
            return new List<Client>() {

                new Client(){
                    ClientId="Guru",

                    AllowedGrantTypes=GrantTypes.ClientCredentials,

                    ClientSecrets=new List<Secret>(){
                        new Secret("GuruKey")
                    },

                    AllowedScopes={"First API" }
                }
            };
        }


    }
}
