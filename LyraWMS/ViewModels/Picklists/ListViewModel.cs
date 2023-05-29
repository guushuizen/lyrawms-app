using System.Windows.Input;
using CommunityToolkit.Maui.Views;
using LyraWMS.Models;
using LyraWMS.Services;
using LyraWMS.Views;

namespace LyraWMS.ViewModels.Picklists;

public class ListViewModel : BaseViewModel
{

    private readonly PicklistService _picklistService;

    private List<Picklist> _picklists;
    public List<Picklist> Picklists
    {
        get => _picklists;
        set => SetProperty(ref _picklists, value);
    }

    public ICommand OpenBarcodePopupCommand { get; set; }
    
    public ListViewModel(PicklistService picklistService)
    {
        _picklistService = picklistService;

        Loading = true;
        
        Task.Run(Initialize);

        OpenBarcodePopupCommand = new Command(async () => await OpenBarcodePopup());
    }

    private async Task Initialize()
    {
        Picklists = await _picklistService.GetPicklists();

        Loading = false;
    }
    
    private async Task OpenBarcodePopup()
    {
        await BarcodeScanner.Mobile.Methods.AskForRequiredPermission();

        await Shell.Current.Navigation.PushModalAsync(new BarcodePage(
            new Command(async (barcode) => {
                await Shell.Current.GoToAsync((string)barcode);
            })
        ));
    }

}