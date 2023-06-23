using WMS.ViewModels.Products;

namespace WMS.Views.Products;

public partial class ProductListPage : ContentPage
{
    public ProductListPage(ProductListViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }
}
