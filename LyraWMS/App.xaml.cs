using LyraWMS.Services;
using LyraWMS.Views;

namespace LyraWMS;

public partial class App : Application
{
    private readonly AuthenticationService _authenticationService;
    
    public App(AuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
        
        InitializeComponent();

        MainPage = new LoadingPage();
    }

    protected override void OnStart()
    {
        var task = _authenticationService.GetCredentials();

        task.ContinueWith(task =>
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                MainPage = new AppShell();

                var (subdomain, apiToken) = task.Result;

                if (string.IsNullOrWhiteSpace(subdomain) || string.IsNullOrWhiteSpace(apiToken))
                {
                    await Shell.Current.GoToAsync($"///{nameof(LoginPage)}");
                    return;
                }

                bool result = await _authenticationService.AttemptLogin(subdomain, apiToken);
                
                if (!result) {
                    await Shell.Current.GoToAsync($"///{nameof(LoginPage)}");
                }
            });
        });
        
        base.OnStart();
    }
}