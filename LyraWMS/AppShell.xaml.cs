using LyraWMS.Views.Picklists;

namespace LyraWMS;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		
		Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));
	}
}

