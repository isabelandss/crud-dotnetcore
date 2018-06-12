using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiUsuarios.Services
{
    public class HttpService
    {
        HttpClient client;
        public HttpService(HttpClient _client)
        {
            client = _client;
        }

        public dynamic get(string url) 
        {
            var result = new object();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();

            string conteudo = response.Content.ReadAsStringAsync().Result;
            dynamic resultado = JsonConvert.DeserializeObject(conteudo);

            result = resultado;

            return result;
        }
    }
}