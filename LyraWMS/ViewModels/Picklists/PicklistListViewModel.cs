using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Maui.Views;
using LyraWMS.Models;
using LyraWMS.Services;
using LyraWMS.Services.Interfaces;
using LyraWMS.Views;
using LyraWMS.Views.Picklists;
using LyraWMS.Views.Products;

namespace LyraWMS.ViewModels.Picklists;

public class PicklistListViewModel : BaseViewModel
{
    private readonly PicklistService _picklistService;

    private ObservableCollection<Picklist> _picklists;

    public ObservableCollection<Picklist> Picklists
    {
        get => _picklists;
        set => SetProperty(ref _picklists, value);
    }

    private int nextPageToLoad;
    
    private INotificationService _notificationService;

    public ICommand OpenBarcodePopupCommand { get; set; }
    public ICommand GoToPicklistCommand { get; set; }
    public ICommand LoadMorePicklistsCommand { get; set; }

    public PicklistListViewModel(PicklistService picklistService, INotificationService notificationService)
    {
        _picklistService = picklistService;
        _notificationService = notificationService;

        Task.Run(Initialize);

        OpenBarcodePopupCommand = new Command(async () => await OpenBarcodePopup());
        GoToPicklistCommand = new Command(
            async (picklistId) => await GoToPicklist((string)picklistId)
        );
        LoadMorePicklistsCommand = new Command(async () => await LoadMorePicklists());
    }

    public async Task Initialize()
    {
        Loading = true;

        Picklists = new ObservableCollection<Picklist>(
            await _picklistService.GetPicklists(nextPageToLoad)
        );
        nextPageToLoad++;

        Loading = false;
    }

    public void Clear()
    {
        Loading = true;

        Picklists = new ObservableCollection<Picklist>();
    }

    private async Task OpenBarcodePopup()
    {
        await Shell.Current.Navigation.PushModalAsync(
            new BarcodePage(new Command(barcode => GoToPicklistCommand.Execute((string)barcode)))
        );
    }

    private async Task GoToPicklist(string picklistId)
    {
        Picklist? picklist = await _picklistService.FindPicklist(picklistId);

        await Shell.Current.Navigation.PopModalAsync();

        if (picklist == null)
        {
            await _notificationService.DisplayAlert(
                "Niet gevonden",
                "Een open picklist met deze ID kon niet gevonden worden!",
                "OK"
            );

            return;
        }

        await Shell.Current.GoToAsync(
            $"{nameof(PicklistListPage)}/{nameof(PicklistDetailPage)}",
            new Dictionary<string, object> { { nameof(Picklist), picklist } }
        );
    }

    private async Task LoadMorePicklists()
    {
        List<Picklist> newPicklists = await _picklistService.GetPicklists(nextPageToLoad);

        newPicklists.ForEach(p => Picklists.Add(p));

        nextPageToLoad++;
    }
}
