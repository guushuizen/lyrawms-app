using CommunityToolkit.Mvvm.ComponentModel;

namespace WMS.Models.ObservableModels;

public partial class ObservableProduct : ObservableObject
{
    private readonly Product _product;

    public ObservableProduct(Product product) => _product = product;

    private int _pickedQuantity;

    public int PickedQuantity
    {
        get => _pickedQuantity;
        set => SetProperty(ref _pickedQuantity, value);
    }

    public int PickableQuantity => _product.Pivot!.Amount;
    public string Sku => _product.Sku;
    public string Name => _product.Name;
    public List<ProductLocation> ProductLocations => _product.ProductLocations;
}
