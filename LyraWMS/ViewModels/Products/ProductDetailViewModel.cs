using System.Windows.Input;
using LyraWMS.Models;
using LyraWMS.Services;
using LyraWMS.Views.Products;

namespace LyraWMS.ViewModels.Products;

[QueryProperty(nameof(Product), "Product")]
public class ProductDetailViewModel : BaseViewModel
{
    private Product _product;
    public Product Product
    {
        get => _product;
        set {
            SetProperty(ref _product, value);
            Loading = false;
        }
    }
    
    public ICommand GoToTransferStockPageCommand { get; set; }

    private ProductService _productService;
    
    public ProductDetailViewModel(ProductService productService)
    {
        Loading = true;

        _productService = productService;

        GoToTransferStockPageCommand = new Command(async () => await GoToTransferStockPage());
    }

    private async Task GoToTransferStockPage()
    {
        await Shell.Current.GoToAsync(
            $"{nameof(ProductListPage)}/{nameof(ProductDetailPage)}/{nameof(TransferStockPage)}",
            new Dictionary<string, object>
            {
                {nameof(Product), Product}
            }
        );
    }

    public async Task Refresh()
    {
        if (Product == null) return;
        
        Loading = true;
        
        Product = await _productService.FindProduct(Product.Sku);

        Loading = false;
    }
}