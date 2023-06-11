using LyraWMS.Services;
using LyraWMS.Services.Interfaces;
using LyraWMS.Views;

namespace LyraWMS;

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
