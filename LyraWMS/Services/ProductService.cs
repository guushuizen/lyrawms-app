using System.Net;
using System.Text.Json;
using System.Text.Json.Nodes;
using LyraWMS.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LyraWMS.Services;

public class ProductService 
{
    private readonly AuthorizedAPIService _apiService;

    public ProductService(AuthorizedAPIService apiService)
    {
        _apiService = apiService;
    }

    public async Task<List<Product>> GetProducts(int page = 0)
    {
        HttpResponseMessage response = await _apiService.GetAsync($"/products?page={page}");

        List<Product> products = _apiService.DeserializeJson<List<Product>>(
            await response.Content.ReadAsStringAsync(),
            "rows"
        );

        return products;
    }

    public async Task<Product?> FindProduct(string sku)
    {
        HttpResponseMessage response = await _apiService.GetAsync($"/products?search={sku}");

        var products = _apiService.DeserializeJson<List<Product>>(await response.Content.ReadAsStringAsync(), "rows");

        if (products.Count == 0)
            return null;
        
        return products.First();
    }
}