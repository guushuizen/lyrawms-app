using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using BarcodeScanner.Mobile;
using CommunityToolkit.Maui.Markup;
using LyraWMS.Services;
using LyraWMS.ViewModels;

using PicklistViewModels = LyraWMS.ViewModels.Picklists;
using PicklistViews = LyraWMS.Views.Picklists;
using ProductViews = LyraWMS.Views.Products;
using ProductViewModels = LyraWMS.ViewModels.Products;
using LyraWMS.Views;

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

		builder.Services.AddScoped<LoginPageViewModel>();
		builder.Services.AddScoped<LoginPage>();

		builder.Services.AddTransient<DashboardViewModel>();
		builder.Services.AddTransient<Dashboard>();

		builder.Services.AddScoped<ProductViewModels.ListViewModel>();
		builder.Services.AddScoped<ProductViews.ListPage>();
		builder.Services.AddTransient<ProductViewModels.DetailViewModel>();
		builder.Services.AddTransient<ProductViews.ProductDetailPage>();
	
		builder.Services.AddTransient<BarcodePage>();

		builder.Services.AddScoped<PicklistViews.ListPage>();
		builder.Services.AddScoped<PicklistViewModels.ListViewModel>();
		builder.Services.AddTransient<PicklistViews.PicklistDetailPage>();
		builder.Services.AddTransient<PicklistViewModels.DetailViewModel>();

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

