using LyraWMS.ViewModels.Products;

namespace LyraWMS.Views.Products;

public partial class ListPage : ContentPage
{
    public ListPage(ListViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }
}