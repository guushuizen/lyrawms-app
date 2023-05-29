using System.ComponentModel;
using System.Windows.Input;
using LyraWMS.Services;
using LyraWMS.Views;

namespace LyraWMS.ViewModels;

public class LoginPageViewModel : BaseViewModel
{
    public event PropertyChangedEventHandler PropertyChanged;

    private readonly AuthenticationService _authenticationService;

    private string _subdomain;

    public string Subdomain
    {
        get => _subdomain;
        set
        {
            _subdomain = value;
            OnPropertyChanged();
        }
    }

    private string _apiToken;

    public string ApiToken
    {
        get => _apiToken;
        set
        {
            _apiToken = value;
            OnPropertyChanged();
        }
    }

    public ICommand LoginCommand { get; set; }

    public LoginPageViewModel(AuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
        
        LoginCommand = new Command(async () => await AttemptLogin());
    }

    private async Task AttemptLogin()
    {
        bool result = await _authenticationService.AttemptLogin(Subdomain, ApiToken);

        if (!result)
        {
            await Application.Current.MainPage.DisplayAlert("Incorrecte gegevens", "De combinatie van subdomein en API token is niet juist.", "OK");
        }
        else
        {
            await Shell.Current.GoToAsync($"//{nameof(Dashboard)}");
        }
    }
}