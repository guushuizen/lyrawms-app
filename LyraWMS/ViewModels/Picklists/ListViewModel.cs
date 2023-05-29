using System.Windows.Input;
using CommunityToolkit.Maui.Views;
using LyraWMS.Models;
using LyraWMS.Services;
using LyraWMS.Views;
using LyraWMS.Views.Picklists;

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
    
    public ICommand GoToPicklistCommand { get; set; }
    
    public ListViewModel(PicklistService picklistService)
    {
        _picklistService = picklistService;

        Loading = true;
        
        Task.Run(Initialize);

        OpenBarcodePopupCommand = new Command(async () => await OpenBarcodePopup());
        GoToPicklistCommand = new Command(async (picklistId) => await GoToPicklist((string) picklistId));
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
            new Command(barcode => GoToPicklistCommand.Execute((string)barcode))
        ));
    }

    private async Task GoToPicklist(string picklistId)
    {
        Picklist? picklist = await _picklistService.GetPicklist(picklistId);

        await Shell.Current.Navigation.PopModalAsync();
        
        if (picklist == null)
        {
            await Shell.Current.DisplayAlert(
                "Niet gevonden",
                "Een picklist met deze ID kon niet gevonden worden!",
                "OK"
            );

            return;
        }

        await Shell.Current.GoToAsync(nameof(DetailPage), new Dictionary<string, object>
        {
            { nameof(Picklist), picklist }
        });
    }
}