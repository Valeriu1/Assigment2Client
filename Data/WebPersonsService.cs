using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Models;

namespace Assigment1.Data
{
    public class WebPersonsService : IPersonsService
    {
        private string uri = "https://localhost:5003";
        private readonly HttpClient client;
      

       

        public WebPersonsService()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            client = new HttpClient(clientHandler);
        }
        

        public async Task<IList<Adult>> GetPersonsAsync()
        {
           
            HttpResponseMessage response = await client.GetAsync(uri + "/Persons");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($@"Error: {response.StatusCode}, {response.ReasonPhrase}");
            }

            string message = await response.Content.ReadAsStringAsync();
            List<Adult> result =  JsonSerializer.Deserialize<List<Adult>>(message,  new JsonSerializerOptions {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return result;
           
        }

        public async Task AddPersonAsync(Adult adult)
        {
            string personAsJson = JsonSerializer.Serialize(adult);
            HttpContent content = new StringContent(personAsJson,
                Encoding.UTF8,
                "application/json");
            await client.PostAsync(uri+"/Persons", content);
            
        }

        public async Task RemovePersonAsync(int personId)
        {
            await client.DeleteAsync($"{uri}/Persons/{personId}");
        }

        public async Task UpdateAsync(Adult adult)
        {
            string personAsJson = JsonSerializer.Serialize(adult);
            HttpContent content = new StringContent(personAsJson,
                Encoding.UTF8,
                "application/json");
            HttpResponseMessage response = await client.PutAsync($"{uri}/Persons/{adult.Id}", content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error, {response.StatusCode}, {response.ReasonPhrase}");
            }
        }

        public async Task<Adult> GetAsync(int id)
        {
            Task<string> stringAsync = client.GetStringAsync($"{uri}/Persons/{id}");
            string message = await stringAsync;
            Adult result = JsonSerializer.Deserialize<Adult>(message,new JsonSerializerOptions {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return result;
        }
    }
}