using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using BarcodeScanner.Mobile;
using CommunityToolkit.Maui.Markup;
using WMS.Services;
using WMS.Services.Interfaces;
using WMS.ViewModels;
using WMS.ViewModels.Picklists;
using WMS.ViewModels.Products;
using WMS.Views;
using WMS.Views.Picklists;
using WMS.Views.Products;

namespace WMS;

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
        builder.Services.AddSingleton<IAuthenticationService, AuthenticationService>();
        builder.Services.AddSingleton<PicklistService>();
        builder.Services.AddSingleton<IProductService, ProductService>();
        builder.Services.AddSingleton<IStorageService, StorageService>();
        builder.Services.AddSingleton<INotificationService, NotificationService>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
