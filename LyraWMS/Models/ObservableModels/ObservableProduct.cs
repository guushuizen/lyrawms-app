using CommunityToolkit.Mvvm.ComponentModel;

namespace LyraWMS.Models.ObservableModels;

public partial class ObservableProduct : ObservableObject
{
    private readonly Product _product;

    public ObservableProduct(Product product) => _product = product;

    [ObservableProperty]
    public int pickedQuantity;

    public int PickableQuantity => _product.Pivot!.Amount;
    public string Sku => _product.Sku;
    public string Name => _product.Name;
    public List<ProductLocation> ProductLocations => _product.ProductLocations;
}
