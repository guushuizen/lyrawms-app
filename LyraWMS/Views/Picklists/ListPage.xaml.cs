using LyraWMS.ViewModels.Picklists;

namespace LyraWMS.Views.Picklists;

public partial class ListPage : ContentPage
{
    public ListPage(ListViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
        
        NavigatedTo += (sender, args) => Task.Run(((ListViewModel)BindingContext).Initialize);

        NavigatedFrom += (sender, args) => ((ListViewModel)BindingContext).Clear();
    }
}