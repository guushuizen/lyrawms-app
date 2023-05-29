using LyraWMS.Models;
using LyraWMS.Services;

namespace LyraWMS.ViewModels.Picklists;

public class DetailViewModel : BaseViewModel
{

    private readonly PicklistService _picklistService;

    private List<Picklist> _picklists;
    public List<Picklist> Picklists
    {
        get => _picklists;
        set => SetProperty(ref _picklists, value);
    }

    public DetailViewModel(PicklistService picklistService)
    {
        _picklistService = picklistService;

        Task.Run(async () => await _picklistService.GetPicklists())
            .ContinueWith(task => Picklists = task.Result);
    }
}