using Inveon.eCommerceExample.Carts.API.Models;
using Newtonsoft.Json;

namespace Inveon.eCommerceExample.Carts.API.Services;

public class ProductService : IProductService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ProductService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IEnumerable<Product>?> GetProducts()
    {
        var client = _httpClientFactory.CreateClient("Product");
        var response = await client.GetAsync($"/api/v1/products");
        if (response.StatusCode != System.Net.HttpStatusCode.OK)
        {
            return null;
        }

        var content = await response.Content.ReadAsStringAsync();
        var products =
            JsonConvert.DeserializeObject<IEnumerable<Product>>(content);

        return products;
    }

    public async Task<Product?> GetProduct(Guid id)
    {
        var client = _httpClientFactory.CreateClient("Product");
        var response = await client.GetAsync($"/api/v1/products/{id}");
        if (response.StatusCode != System.Net.HttpStatusCode.OK)
        {
            return null;
        }

        var content = await response.Content.ReadAsStringAsync();
        var product =
            JsonConvert.DeserializeObject<Product>(content);

        return product;
    }
}
