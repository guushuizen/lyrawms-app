using System.Windows.Input;
using LyraWMS.Models;
using LyraWMS.Services;

namespace LyraWMS.ViewModels.Picklists;

[QueryProperty(nameof(Picklist), "Picklist")]
public class DetailViewModel : BaseViewModel
{
    private Picklist _picklist;
    public Picklist Picklist
    {
        get => _picklist;
        set => SetProperty(ref _picklist, value);
    }

    private readonly PicklistService _picklistService;

    public ICommand GoBackCommand { get; set; }
    
    public DetailViewModel(PicklistService picklistService)
    {
        _picklistService = picklistService;

        GoBackCommand = new Command(async () => await GoBack());
    }

    private async Task GoBack()
    {
        await Shell.Current.Navigation.PopAsync();
    }
}