using LyraWMS.ViewModels.Products;

namespace LyraWMS.Views.Products;

public partial class ProductDetailPage : ContentPage
{
    public ProductDetailPage(ProductDetailViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;

        // Shell.Current.Navigating += (sender, args) =>
        // {
        //     if (args.Current.Location.OriginalString.EndsWith(nameof(TransferStockPage)) 
        //         && args.Target.Location.OriginalString.Equals(".."))
        //     {
        //         Task.Run(viewModel.Refresh);
        //     }
        // };
    }
}