using WMS.Services;
using WMS.Services.Interfaces;
using WMS.Views;

namespace WMS;

public partial class App : Application
{
    public App(IAuthenticationService authenticationService, IServiceProvider serviceProvider)
    {
        InitializeComponent();

        var user = Task.Run(authenticationService.GetCurrentUser).Result;

        if (user != null)
        {
            MainPage = new AppShell();
        }
        else
        {
            MainPage = new LoginShell();
        }
    }
}
