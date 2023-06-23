using System.Net;
using System.Text.Json;
using System.Text.Json.Nodes;
using WMS.Models;
using WMS.Services.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Location = WMS.Models.Location;

namespace WMS.Services;

public class ProductService : IProductService
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

        var products = _apiService.DeserializeJson<List<Product>>(
            await response.Content.ReadAsStringAsync(),
            "rows"
        );

        if (products.Count == 0)
            return null;

        return products.First();
    }

    public async Task<List<Location>> GetAvailableLocations(Product product, Warehouse warehouse)
    {
        HttpResponseMessage response = await _apiService.GetAsync(
            $"/warehouse/locations/available-fo-stock-allocation?product={product.Uuid}&warehouse={warehouse.Uuid}"
        );

        List<Location> locations = _apiService.DeserializeJson<List<Location>>(
            await response.Content.ReadAsStringAsync(),
            "locations"
        );

        return locations;
    }

    public async Task<List<Warehouse>> GetWarehouses()
    {
        HttpResponseMessage response = await _apiService.GetAsync("/warehouses");

        return _apiService.DeserializeJson<List<Warehouse>>(
            await response.Content.ReadAsStringAsync(),
            "warehouses"
        );
    }

    public async Task<bool> MoveStock(
        Product product,
        int amount,
        Location newLocation,
        ProductLocation oldProductLocation
    )
    {
        var response = await _apiService.PostAsync(
            $"/stock-move/{oldProductLocation.Id}",
            new Dictionary<string, object>
            {
                { "to", newLocation.Uuid },
                { "amount", amount },
                { "instant", true }
            }
        );

        return response.IsSuccessStatusCode;
    }
}
