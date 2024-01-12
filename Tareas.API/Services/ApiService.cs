using Newtonsoft.Json;
using Tareas.Shared.Responses;

namespace Tareas.API.Services
{
    public class ApiService : IApiService
    {
        private readonly IConfiguration _configuration;
        private readonly string _urlBase;
        private readonly string _tokenName;
        private readonly string _tokenValue;

        public ApiService(IConfiguration configuration)
        {
            _configuration = configuration;
            _urlBase = configuration["CountriesApi:urlBase"]!;
            _tokenName = configuration["CountriesApi:tokenName"]!;
            _tokenValue = configuration["CountriesApi:tokenValue"]!;
        }
        public async Task<Response> GetListAsync<T>(string servicePrefix, string controller)
        {
            try
            {
                HttpClient client = new()
                {
                    BaseAddress = new Uri(_urlBase)
                };

                client.DefaultRequestHeaders.Add(_tokenName, _tokenValue);
                string url = $"{servicePrefix}{controller}";
                HttpResponseMessage response = await client.GetAsync(url);

                string result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response { IsSuccess = false, Message = result };
                }

                List<T> list = JsonConvert.DeserializeObject<List<T>>(result)!;
                return new Response { IsSuccess = true, Result = list };

            }catch (Exception ex)
            {
                return new Response { IsSuccess = false, Message = ex.Message };
            }
        }
    }
}