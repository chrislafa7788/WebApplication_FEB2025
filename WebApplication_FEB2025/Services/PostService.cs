using System.Net.Http;
using System.Text.Json;
using WebApplication_FEB2025.DTOs;

namespace WebApplication_FEB2025.Services
{
    public class PostService :IPostService
    {
        private HttpClient _httpClient;

        public PostService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //el async va aca en la interface no porq debe tener cuerpo para tener async.
        public async Task<IEnumerable<PostDto>> Get()
        {            
            var result = await _httpClient.GetAsync(_httpClient.BaseAddress);
            var body = await result.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {

                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<IEnumerable<PostDto>>(body,options);
             
        }
    }
}
