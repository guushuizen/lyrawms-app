using System.Windows.Input;
using LyraWMS.Models;
using LyraWMS.Models.ObservableModels;
using LyraWMS.Services;
using LyraWMS.Views;

namespace LyraWMS.ViewModels.Picklists;

[QueryProperty(nameof(Picklist), "Picklist")]
public class DetailViewModel : BaseViewModel
{
    private ObservablePicklist _fullPicklist;
    public ObservablePicklist FullPicklist
    {
        get => _fullPicklist;
        set => SetProperty(ref _fullPicklist, value);
    }
    
    private Picklist _picklist;
    public Picklist Picklist
    {
        get => _picklist;
        set {
            SetProperty(ref _picklist, value);
            Task.Run(Initialize);
        }
    }
    
    private readonly PicklistService _picklistService;

    public ICommand OpenBarcodePopupCommand { get; set; }
    public ICommand DecreasePickedProductQuantityCommand { get; set; }
    public ICommand IncreasePickedProductQuantityCommand { get; set; }

    public DetailViewModel(PicklistService picklistService)
    {
        Loading = true;
        
        _picklistService = picklistService;

        OpenBarcodePopupCommand = new Command(async () => await OpenBarcodePopup());

        DecreasePickedProductQuantityCommand = new Command(sku => DecreasePickedProductQuantity((string) sku));
        IncreasePickedProductQuantityCommand = new Command(sku => IncreasePickedProductQuantity((string) sku));
    }

    private async Task Initialize()
    {
        FullPicklist = new ObservablePicklist(await _picklistService.GetFullPicklist(Picklist.Uuid));
        
        Loading = false;
    }

    private async Task OpenBarcodePopup()
    {
        await Application.Current.MainPage.Navigation.PushModalAsync(new BarcodePage(
            new Command(async (barcode) => await OnBarcodeScanned((string) barcode))
        ));
    }

    private void DecreasePickedProductQuantity(string barcode)
    {
        ObservableProduct? product = FullPicklist.Products.FirstOrDefault(p => p.Sku == barcode);

        if (product != null && product.PickedQuantity > 0)
        {
            FullPicklist.Products.First(p => p.Sku == barcode).PickedQuantity--;
        }
    }

    private void IncreasePickedProductQuantity(string barcode)
    {
        ObservableProduct? product = FullPicklist.Products.FirstOrDefault(p => p.Sku == barcode);

        if (product != null && product.PickedQuantity < product.PickableQuantity)
        {
            FullPicklist.Products.First(p => p.Sku == barcode).PickedQuantity++;
        }
    }
    
    private async Task OnBarcodeScanned(string sku)
    {
        FullPicklist.IncreaseProductQuantity(sku);

        await Application.Current.MainPage.Navigation.PopModalAsync();
    }
}