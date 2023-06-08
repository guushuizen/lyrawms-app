using LyraWMS.ViewModels.Products;

namespace LyraWMS.Views.Products;

public partial class ProductDetailPage : ContentPage
{
    public ProductDetailPage(DetailViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }
}