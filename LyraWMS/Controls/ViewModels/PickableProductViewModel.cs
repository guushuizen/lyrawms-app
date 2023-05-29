using LyraWMS.ViewModels;

namespace LyraWMS.Controls.ViewModels;

public class PickableProductViewModel : BaseViewModel
{
    private int _pickedQuantity;

    public int PickedQuantity
    {
        get => _pickedQuantity;
        set => SetProperty(ref _pickedQuantity, value);
    }

    public PickableProductViewModel()
    {
        
    }
}