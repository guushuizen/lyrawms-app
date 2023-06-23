using WMS.ViewModels.Products;

namespace WMS.Views.Products;

public partial class ProductDetailPage : ContentPage
{
    public ProductDetailPage(ProductDetailViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }
}
