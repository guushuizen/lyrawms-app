using WMS.ViewModels.Picklists;

namespace WMS.Views.Picklists;

public partial class PicklistListPage : ContentPage
{
    public PicklistListPage(PicklistListViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;

        NavigatedTo += (sender, args) =>
            Task.Run(((PicklistListViewModel)BindingContext).Initialize);

        NavigatedFrom += (sender, args) => ((PicklistListViewModel)BindingContext).Clear();
    }
}
