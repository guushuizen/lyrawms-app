using CommunityToolkit.Mvvm.ComponentModel;

namespace LyraWMS.ViewModels;

public class BaseViewModel : ObservableRecipient
{
    protected bool _loading;
    public bool Loading
    {
        get => _loading;
        set => SetProperty(ref _loading, value);
    }
}
