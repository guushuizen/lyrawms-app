using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Messaging;
using LyraWMS.Messages;
using LyraWMS.Models;
using LyraWMS.Services;
using LyraWMS.Views;

namespace LyraWMS.ViewModels.Picklists;

[QueryProperty(nameof(Picklist), "Picklist")]
public class DetailViewModel : BaseViewModel
{
    private FullPicklist _fullPicklist;
    public FullPicklist FullPicklist
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

    public ObservableCollection<KeyValuePair<string, int>> PickedQuantites { get; set; } = new();
    
    public ICommand OpenBarcodePopupCommand { get; set; }

    public DetailViewModel(PicklistService picklistService)
    {
        Loading = true;
        
        _picklistService = picklistService;

        OpenBarcodePopupCommand = new Command(async () => await OpenBarcodePopup());
    }

    private async Task Initialize()
    {
        FullPicklist = await _picklistService.GetFullPicklist(Picklist.Uuid);
        
        Loading = false;
    }

    private async Task GoBack()
    {
        await Shell.Current.Navigation.PopAsync();
    }

    private async Task OpenBarcodePopup()
    {
        await Application.Current.MainPage.Navigation.PushModalAsync(new BarcodePage(
            new Command(async (barcode) => await OnBarcodeScanned((string) barcode))
        ));
    }

    private async Task OnBarcodeScanned(string sku)
    {
        Product? product = FullPicklist.Products.Find(p => p.Sku == sku);

        if (product != null)
        {
            WeakReferenceMessenger.Default.Send(new ProductPickedMessage(product));
        }

        await Application.Current.MainPage.Navigation.PopModalAsync();
    }
}