using System.Windows.Input;
using LyraWMS.Models;
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

    public ProductDetailViewModel()
    {
        GoToTransferStockPageCommand = new Command(async () => await GoToTransferStockPage());
    }

    private async Task GoToTransferStockPage()
    {
        await Shell.Current.GoToAsync(
            $"{nameof(ProductListPage)}/{nameof(ProductDetailPage)}/{nameof(TransferStockPage)}"
        );
    }
}