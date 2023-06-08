using LyraWMS.Views.Picklists;
using LyraWMS.Views.Products;

namespace LyraWMS;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		
		Routing.RegisterRoute(nameof(PicklistDetailPage), typeof(PicklistDetailPage));
		Routing.RegisterRoute(nameof(ProductDetailPage), typeof(ProductDetailPage));
	}
}

