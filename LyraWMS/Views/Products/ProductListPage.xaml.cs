using LyraWMS.ViewModels.Products;

namespace LyraWMS.Views.Products;

public partial class ProductListPage : ContentPage
{
    public ProductListPage(ProductListViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }
}
