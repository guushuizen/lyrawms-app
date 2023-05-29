using System.Net;
using System.Text.Json;
using System.Text.Json.Nodes;
using LyraWMS.Models;
using LyraWMS.Views;

namespace LyraWMS.Services;

public class AuthenticationService
{
    private User _user;

    public async Task<User?> GetCurrentUser()
    {
        if (_user is not null)
        {
            return _user;
        }
        else
        {
            var (subdomain, apiToken) = await GetCredentials();

            if (!await AttemptLogin(subdomain, apiToken))
            {
                // If we're requesting a user while we're not logged in, something's wrong.
                await Logout();
                
                return null;
            }

            return _user;
        }
    }


    public async Task<bool> AttemptLogin(string subdomain, string apiToken)
    {
        // We don't recycle this one because we'll use different headers each time
        HttpClient httpClient = new HttpClient(new HttpClientHandler
        {
            AllowAutoRedirect = false,
        });
        
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

                _user = body["user"].Deserialize<User>(new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return true;
            }
        } catch {
            SecureStorage.RemoveAll();
        }

        return false;
    }

    private async Task StoreCredentials(string subdomain, string apiToken)
    {
        await SecureStorage.SetAsync("subdomain", subdomain);
        await SecureStorage.SetAsync("apiToken", apiToken);
    }

    public async Task<(string, string)> GetCredentials()
    {
        var subdomain = await SecureStorage.GetAsync("subdomain");
        var apiToken = await SecureStorage.GetAsync("apiToken");

        if (subdomain is null || apiToken is null)
        {
            SecureStorage.RemoveAll();

            return ("", "");
        }

        return new ValueTuple<string, string>(subdomain, apiToken);
    }

    public async Task Logout()
    {
        SecureStorage.RemoveAll();

        _user = null;

        await Shell.Current.GoToAsync($"///{nameof(LoginPage)}");
    }
}