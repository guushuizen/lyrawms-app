using System.Text.Json.Nodes;
using System.Windows.Input;
using WMS.Models;
using WMS.Services;
using WMS.Services.Interfaces;
using WMS.Views;

namespace WMS.ViewModels;

public class DashboardViewModel : BaseViewModel
{
    private readonly AuthorizedAPIService _apiService;

    private readonly IAuthenticationService _authenticationService;

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
        IAuthenticationService authenticationService
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
        _authenticationService.Logout();

        Application.Current.MainPage = new LoginShell();
    }
}
