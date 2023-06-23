using System.Net;
using System.Text.Json;
using System.Text.Json.Nodes;
using WMS.Models;
using WMS.Services.Interfaces;

namespace WMS.Services;

public class AuthenticationService : IAuthenticationService
{
    private User? _user;

    private readonly IStorageService _storageService;

    public AuthenticationService(IStorageService storageService)
    {
        _storageService = storageService;
    }

    public async Task<User?> GetCurrentUser()
    {
        if (_user is not null)
        {
            return _user;
        }

        var credentials = await GetCredentials();

        if (credentials == null)
        {
            return null;
        }

        User? user = await AttemptLogin(credentials.Item1, credentials.Item2);
        if (user != null)
        {
            _user = user;
            return _user;
        }

        return null;
    }

    public async Task<User?> AttemptLogin(string subdomain, string apiToken)
    {
        // We don't recycle this one because we'll use different headers each time
        HttpClient httpClient = new HttpClient(
            new HttpClientHandler { AllowAutoRedirect = false, }
        );

        httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiToken}");
        httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        httpClient.BaseAddress = new Uri($"https://{subdomain}.lyrawms.nl");

        try
        {
            HttpResponseMessage responseMessage = await httpClient.GetAsync("/api/v1/confirm");

            if (responseMessage.StatusCode == HttpStatusCode.OK)
            {
                await StoreCredentials(subdomain, apiToken);

                var response = await httpClient.GetAsync("/user/settings");

                var body = JsonNode.Parse(await response.Content.ReadAsStringAsync());

                return body["user"].Deserialize<User>(
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );
            }
        }
        catch
        {
            _storageService.RemoveAll();
        }

        return null;
    }

    private async Task StoreCredentials(string subdomain, string apiToken)
    {
        await _storageService.SetAsync("subdomain", subdomain);
        await _storageService.SetAsync("apiToken", apiToken);
    }

    public async Task<Tuple<string, string>?> GetCredentials()
    {
        var subdomain = await _storageService.GetAsync("subdomain");
        var apiToken = await _storageService.GetAsync("apiToken");

        if (string.IsNullOrEmpty(subdomain) || string.IsNullOrEmpty(apiToken))
        {
            _storageService.RemoveAll();

            return null;
        }

        return new Tuple<string, string>(subdomain, apiToken);
    }

    public void Logout()
    {
        _storageService.RemoveAll();

        _user = null;
    }
}
