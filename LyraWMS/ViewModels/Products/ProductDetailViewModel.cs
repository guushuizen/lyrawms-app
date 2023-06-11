using System.Windows.Input;
using LyraWMS.Models;
using LyraWMS.Services;
using LyraWMS.Services.Interfaces;
using LyraWMS.Views.Products;

namespace LyraWMS.ViewModels.Products;

[QueryProperty(nameof(Product), "Product")]
[QueryProperty(nameof(ShouldRefresh), "ShouldRefresh")]
public class ProductDetailViewModel : BaseViewModel
{
    private Product _product;
    public Product Product
    {
        get => _product;
        set
        {
            SetProperty(ref _product, value);
            Loading = false;
        }
    }

    private bool _shouldRefresh;
    public bool ShouldRefresh
    {
        get => _shouldRefresh;
        set
        {
            SetProperty(ref _shouldRefresh, value);
            if (value)
            {
                Task.Run(Refresh);
            }
        }
    }

    public ICommand GoToTransferStockPageCommand { get; set; }

    private IProductService _productService;

    public ProductDetailViewModel(IProductService productService)
    {
        Loading = true;

        _productService = productService;

        GoToTransferStockPageCommand = new Command(async () => await GoToTransferStockPage());
    }

    private async Task GoToTransferStockPage()
    {
        await Shell.Current.GoToAsync(
            $"{nameof(ProductListPage)}/{nameof(ProductDetailPage)}/{nameof(TransferStockPage)}",
            new Dictionary<string, object> { { nameof(Product), Product } }
        );
    }

    public async Task Refresh()
    {
        if (Product == null)
            return;

        Loading = true;

        Product = await _productService.FindProduct(Product.Sku);

        Loading = false;
    }
}
