using CommunityToolkit.Maui;
using BarcodeScanner.Mobile;
using CommunityToolkit.Maui.Markup;
using LyraWMS.Controls;
using LyraWMS.Controls.ViewModels;
using LyraWMS.Services;
using LyraWMS.ViewModels;
using LyraWMS.ViewModels.Picklists;
using LyraWMS.Views;
using LyraWMS.Views.Picklists;
using Microsoft.Extensions.Logging;

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

		builder.Services.AddScoped<ListViewModel>();
		builder.Services.AddScoped<ListPage>();

		builder.Services.AddTransient<BarcodePage>();

		builder.Services.AddTransient<DetailPage>();
		builder.Services.AddTransient<DetailViewModel>();

		builder.Services.AddTransient<PickableProduct>();
		builder.Services.AddTransient<PickableProductViewModel>();

		builder.Services.AddSingleton<AuthorizedAPIService>();
		builder.Services.AddSingleton<AuthenticationService>();
		builder.Services.AddSingleton<PicklistService>();

		
#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

