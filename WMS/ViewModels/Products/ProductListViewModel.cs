using System.Collections.ObjectModel;
using System.Windows.Input;
using WMS.Models;
using WMS.Services;
using WMS.Services.Interfaces;
using WMS.Views;
using WMS.Views.Products;

namespace WMS.ViewModels.Products;

public class ProductListViewModel : BaseViewModel
{
    private readonly IProductService _productService;
    private readonly INotificationService _notificationService;

    private ObservableCollection<Product> _products;
    public ObservableCollection<Product> Products
    {
        get => _products;
        set => SetProperty(ref _products, value);
    }

    private int nextPageToLoad;

    public ICommand OpenBarcodePopupCommand { get; set; }
    public ICommand GoToProductCommand { get; set; }

    public ICommand LoadMoreProductsCommand { get; set; }

    public ProductListViewModel(
        IProductService productService,
        INotificationService notificationService
    )
    {
        _productService = productService;
        _notificationService = notificationService;

        Loading = true;

        Task.Run(Initialize);

        OpenBarcodePopupCommand = new Command(async () => await OpenBarcodePopup());
        GoToProductCommand = new Command(async (productId) => await GoToProduct((string)productId));
        LoadMoreProductsCommand = new Command(async () => await LoadMoreProducts());
    }

    private async Task Initialize()
    {
        Products = new ObservableCollection<Product>(
            await _productService.GetProducts(nextPageToLoad)
        );
        nextPageToLoad++;

        Loading = false;
    }

    private async Task LoadMoreProducts()
    {
        var products = await _productService.GetProducts(nextPageToLoad);
        products.ForEach(p => Products.Add(p));
        nextPageToLoad++;
    }

    private async Task OpenBarcodePopup()
    {
        await Shell.Current.Navigation.PushModalAsync(
            new BarcodePage(new Command(barcode => GoToProductCommand.Execute((string)barcode)))
        );
    }

    private async Task GoToProduct(string productId)
    {
        Product? product = await _productService.FindProduct(productId);

        await Shell.Current.Navigation.PopModalAsync();

        if (product == null)
        {
            await _notificationService.DisplayAlert(
                "Niet gevonden",
                "Een product met deze ID kon niet gevonden worden!",
                "OK"
            );

            return;
        }

        await Shell.Current.GoToAsync(
            $"{nameof(ProductListPage)}/{nameof(ProductDetailPage)}",
            new Dictionary<string, object> { { nameof(Product), product } }
        );
    }
}
