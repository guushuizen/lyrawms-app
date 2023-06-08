using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Messaging;
using LyraWMS.Messages;
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

    public ObservableCollection<KeyValuePair<string, int>> PickedQuantites { get; set; } = new();
    
    public ICommand OpenBarcodePopupCommand { get; set; }
    
    public ICommand DecreasePickedProductQuantityCommand { get; set; }
    public ICommand IncreasePickedProductQuantityCommand { get; set; }

    public DetailViewModel(ProductService productService)
    {
        _productService = productService;

        OpenBarcodePopupCommand = new Command(async () => await OpenBarcodePopup());

        DecreasePickedProductQuantityCommand = new Command(product => DecreasePickedProductQuantity((Product) product));
        IncreasePickedProductQuantityCommand = new Command(product => IncreasePickedProductQuantity((Product) product));
    }

    private async Task OpenBarcodePopup()
    {
        await Application.Current.MainPage.Navigation.PushModalAsync(new BarcodePage(
            new Command(async (barcode) => await OnBarcodeScanned((string) barcode))
        ));
    }

    private void DecreasePickedProductQuantity(Product product)
    {
        WeakReferenceMessenger.Default.Send(new ProductUnpickedMessage(product));
    }
    
    private void IncreasePickedProductQuantity(Product product)
    {
        WeakReferenceMessenger.Default.Send(new ProductPickedMessage(product));
    }
    
    private async Task OnBarcodeScanned(string sku)
    {
        await Application.Current.MainPage.Navigation.PopModalAsync();
    }
}