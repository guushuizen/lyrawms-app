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

    private List<Product> _products { get; set; }

    private readonly int ROWS_PER_PAGE = 25;
    
    private int _currentPage = 0;

    public ProductService(AuthorizedAPIService apiService)
    {
        _apiService = apiService;
        
        _products = new List<Product>();
    }

    public async Task<List<Product>> GetProducts(bool newPage = false)
    {
        if (!newPage && _currentPage != 0)
        {
            return _products.GetRange(_currentPage * ROWS_PER_PAGE, ROWS_PER_PAGE);
        }

        HttpResponseMessage response = await _apiService.GetAsync("/products");

        List<Product> products = _apiService.DeserializeJson<List<Product>>(
            await response.Content.ReadAsStringAsync(),
            "rows"
        );

        _products.AddRange(products);

        return products;
    }

    public async Task<Product?> FindProduct(string sku)
    {
        Product? product = _products.FirstOrDefault(p => p.Sku == sku);

        if (product != null)
            return product;
        
        HttpResponseMessage response = await _apiService.GetAsync($"/products?search={sku}");

        var products = _apiService.DeserializeJson<List<Product>>(await response.Content.ReadAsStringAsync(), "rows");

        if (products.Count == 0)
            return null;
        
        _products.Add(products.First());

        return products.First();
    }
}