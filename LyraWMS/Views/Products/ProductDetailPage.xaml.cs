using LyraWMS.ViewModels.Products;

namespace LyraWMS.Views.Products;

public partial class ProductDetailPage : ContentPage
{
    public ProductDetailPage(ProductDetailViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }
}
