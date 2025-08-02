using GlobalApp.Models;
using Newtonsoft.Json;

namespace GlobalApp.Services
{
    public class ProductSearchService
    {
        private readonly HttpClient _httpClient;

        public ProductSearchService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Product>> SearchProductsAsync(string keyword)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://realtime-amazon-data.p.rapidapi.com/product-search?keyword={keyword}&country=mx&page=1&sort=Featured"),
                Headers =
                {
                    { "x-rapidapi-key", "088461e73emsh427bd0ee1e055edp12fda4jsn1693ab9c24b2" },
                    { "x-rapidapi-host", "realtime-amazon-data.p.rapidapi.com" },
                },
            };

            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ProductSearchResponse>(body);
                return result?.Details ?? new List<Product>();
            }
        }
    }
}
