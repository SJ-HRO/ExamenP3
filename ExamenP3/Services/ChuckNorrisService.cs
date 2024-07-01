using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenP3.Services
{
    internal class ChuckNorrisService
    {
        private readonly HttpClient _httpClient;
        public ChuckNorrisService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<string> GetRandomJokeAsync()
        {
            var response = await _httpClient.GetStringAsync("https://api.chucknorris.io/jokes/random");
            var joke = JObject.Parse(response)["value"] = ToString();
            return (string)joke;
        }
    }
}
