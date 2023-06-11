using System.Text.Json.Nodes;
using System.Windows.Input;
using LyraWMS.Models;
using LyraWMS.Services;
using LyraWMS.Views;

namespace LyraWMS.ViewModels;

public class DashboardViewModel : BaseViewModel
{
    private readonly AuthorizedAPIService _apiService;

    private readonly AuthenticationService _authenticationService;

    private User _user;
    public User User
    {
        get => _user;
        set => SetProperty(ref _user, value);
    }

    private DashboardStatistics _statistics;
    public DashboardStatistics Statistics
    {
        get => _statistics;
        set => SetProperty(ref _statistics, value);
    }

    public ICommand LogoutCommand { get; set; }

    public DashboardViewModel(
        AuthorizedAPIService apiService,
        AuthenticationService authenticationService
    )
    {
        _apiService = apiService;
        _authenticationService = authenticationService;

        Loading = true;

        LogoutCommand = new Command(async () => await Logout());

        Task.Run(Initialize);
    }

    public async Task Initialize()
    {
        User = await _authenticationService.GetCurrentUser();
        if (User == null)
        {
            await Logout();
        }
        else
        {
            Statistics = await GetStatistics();

            Loading = false;
        }
    }

    private async Task<DashboardStatistics> GetStatistics()
    {
        HttpResponseMessage httpResponse = await _apiService.GetAsync("count");
        JsonNode responseBody = JsonNode.Parse(await httpResponse.Content.ReadAsStringAsync());

        return new DashboardStatistics
        {
            OrdersCount = responseBody["navigation"]["orders"]["label"].GetValue<int>(),
            BackordersCount = responseBody["navigation"]["backorders"]["label"].GetValue<int>(),
            PicklistCount = responseBody["navigation"]["picklists"]["label"].GetValue<int>(),
            ReturnsCount = responseBody["navigation"]["returns"]["label"].GetValue<int>()
        };
    }

    private async Task Logout()
    {
        await _authenticationService.Logout();

        Application.Current.MainPage = new LoginShell();
    }
}
