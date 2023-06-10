using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using BarcodeScanner.Mobile;
using CommunityToolkit.Maui.Markup;
using LyraWMS.Services;
using LyraWMS.ViewModels;
using LyraWMS.ViewModels.Picklists;
using LyraWMS.ViewModels.Products;
using LyraWMS.Views;
using LyraWMS.Views.Picklists;
using LyraWMS.Views.Products;

namespace LyraWMS;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureMauiHandlers(handlers =>
			{
				handlers.AddBarcodeScannerHandler();
			})
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("OpenSans-Bold.ttf", "OpenSansBold");
			})
			.UseMauiCommunityToolkit()
			.UseMauiCommunityToolkitMarkup();

		builder.Services.AddTransient<LoginPageViewModel>();
		builder.Services.AddTransient<LoginPage>();

		builder.Services.AddTransient<DashboardViewModel>();
		builder.Services.AddTransient<Dashboard>();

		builder.Services.AddTransient<ProductListViewModel>();
		builder.Services.AddTransient<ProductListPage>();
		builder.Services.AddTransient<ProductDetailViewModel>();
		builder.Services.AddTransient<ProductDetailPage>();
	
		builder.Services.AddTransient<BarcodePage>();

		builder.Services.AddTransient<PicklistListPage>();
		builder.Services.AddTransient<PicklistListViewModel>();
		builder.Services.AddTransient<PicklistDetailPage>();
		builder.Services.AddTransient<PicklistDetailViewModel>();
		
		builder.Services.AddTransient<TransferStockPage>();
		builder.Services.AddTransient<TransferStockViewModel>();

		builder.Services.AddSingleton<AuthorizedAPIService>();
		builder.Services.AddSingleton<AuthenticationService>();
		builder.Services.AddSingleton<PicklistService>();
		builder.Services.AddSingleton<ProductService>();
		
#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

