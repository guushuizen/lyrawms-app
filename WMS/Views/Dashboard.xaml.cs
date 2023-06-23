using CommunityToolkit.Maui.Markup;
using WMS.ViewModels;

namespace WMS.Views;

public partial class Dashboard : ContentPage
{
    public Dashboard(DashboardViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        Task.Run(((DashboardViewModel)BindingContext).Initialize);

        base.OnAppearing();
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        Task.Run(((DashboardViewModel)BindingContext).Initialize);

        base.OnNavigatedTo(args);
    }
}
