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

        Task.Run(Initialize);

        OpenBarcodePopupCommand = new Command(async () => await OpenBarcodePopup());
        GoToPicklistCommand = new Command(async (picklistId) => await GoToPicklist((string) picklistId));
    }
    
    public async Task Initialize()
    {
        Loading = true;

        Picklists = await _picklistService.GetPicklists();

        Loading = false;
    }

    public void Clear()
    {
        Loading = true;

        Picklists = new List<Picklist>();
    }
    
    private async Task OpenBarcodePopup()
    {
        await Shell.Current.Navigation.PushModalAsync(new BarcodePage(
            new Command(barcode => GoToPicklistCommand.Execute((string)barcode))
        ));
    }

    private async Task GoToPicklist(string picklistId)
    {
        Picklist? picklist = await _picklistService.FindPicklist(picklistId);

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

        await Shell.Current.GoToAsync(nameof(PicklistDetailPage), new Dictionary<string, object>
        {
            { nameof(Picklist), picklist }
        });
    }
}