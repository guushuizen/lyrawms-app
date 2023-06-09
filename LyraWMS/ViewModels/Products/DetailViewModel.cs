using System.Windows.Input;
using LyraWMS.Models;
using LyraWMS.Services;
using LyraWMS.Views;

namespace LyraWMS.ViewModels.Products;

[QueryProperty(nameof(Product), "Product")]
public class DetailViewModel : BaseViewModel
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
    
    private readonly ProductService _productService;
    
    public ICommand OpenBarcodePopupCommand { get; set; }
    
    public DetailViewModel(ProductService productService)
    {
        _productService = productService;

        OpenBarcodePopupCommand = new Command(async () => await OpenBarcodePopup());

    }

    private async Task OpenBarcodePopup()
    {
        await Application.Current.MainPage.Navigation.PushModalAsync(new BarcodePage(
            new Command(async (barcode) => await OnBarcodeScanned((string) barcode))
        ));
    }

    private async Task OnBarcodeScanned(string sku)
    {
        await Application.Current.MainPage.Navigation.PopModalAsync();
    }
}