using System.Windows.Input;
using LyraWMS.Models;
using LyraWMS.Services;
using LyraWMS.Views;
using LyraWMS.Views.Products;

namespace LyraWMS.ViewModels.Products;

public class ListViewModel : BaseViewModel
{

    private readonly ProductService _productService;

    private List<Product> _products;
    public List<Product> Products
    {
        get => _products;
        set => SetProperty(ref _products, value);
    }

    public ICommand OpenBarcodePopupCommand { get; set; }
    
    public ICommand GoToProductCommand { get; set; }
    
    public ListViewModel(ProductService productService)
    {
        _productService = productService;

        Loading = true;
        
        Task.Run(Initialize);

        OpenBarcodePopupCommand = new Command(async () => await OpenBarcodePopup());
        GoToProductCommand = new Command(async (productId) => await GoToProduct((string) productId));
    }

    private async Task Initialize()
    {
        Products = await _productService.GetProducts();

        Loading = false;
    }
    
    private async Task OpenBarcodePopup()
    {
        await Shell.Current.Navigation.PushModalAsync(new BarcodePage(
            new Command(barcode => GoToProductCommand.Execute((string)barcode))
        ));
    }

    private async Task GoToProduct(string productId)
    {
        Product? product = await _productService.FindProduct(productId);

        await Shell.Current.Navigation.PopModalAsync();
        
        if (product == null)
        {
            await Shell.Current.DisplayAlert(
                "Niet gevonden",
                "Een product met deze ID kon niet gevonden worden!",
                "OK"
            );

            return;
        }

        await Shell.Current.GoToAsync(nameof(DetailPage), new Dictionary<string, object>
        {
            { nameof(Product), product }
        });
    }
}