using LyraWMS.Models;

namespace LyraWMS.ViewModels.Products;

[QueryProperty(nameof(Product), "Product")]
public class TransferStockViewModel : BaseViewModel
{
    
    private Product _product;

    public Product Product
    {
        get => _product;
        set => SetProperty(ref _product, value);
    }
}