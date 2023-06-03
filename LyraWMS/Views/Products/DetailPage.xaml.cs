using LyraWMS.ViewModels.Products;

namespace LyraWMS.Views.Products;

public partial class DetailPage : ContentPage
{
    public DetailPage(DetailViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }
}