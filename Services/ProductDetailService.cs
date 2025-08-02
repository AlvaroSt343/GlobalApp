using GlobalApp.Models;
using Newtonsoft.Json;

namespace GlobalApp.Services
{
    public class ProductDetailService
    {
        private readonly HttpClient _httpClient;

        public ProductDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Método para obtener detalles del producto usando el ASIN(codigo de producto)
        public async Task<ProductDetailResponse> GetProductDetailsAsync(string asin)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://realtime-amazon-data.p.rapidapi.com/product-details?asin={asin}&country=mx"),
                Headers =
                {
                    { "x-rapidapi-key", "088461e73emsh427bd0ee1e055edp12fda4jsn1693ab9c24b2" },
                    { "x-rapidapi-host", "realtime-amazon-data.p.rapidapi.com" },
                },
            };

            try
            {

                // Realizamos la petición
                using (var response = await _httpClient.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var product = JsonConvert.DeserializeObject<ProductDetailResponse>(body);
                    return product;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }
    }
}
