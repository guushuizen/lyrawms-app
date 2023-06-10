using System.Net;
using System.Text.Json;
using System.Text.Json.Nodes;
using LyraWMS.Models;
using LyraWMS.Views;

namespace LyraWMS.Services;

public class AuthenticationService
{
    private User? _user;

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

                return body["user"].Deserialize<User>(new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
        } catch {
            SecureStorage.RemoveAll();
        }
        
        return null;
    }

    private async Task StoreCredentials(string subdomain, string apiToken)
    {
        await SecureStorage.SetAsync("subdomain", subdomain);
        await SecureStorage.SetAsync("apiToken", apiToken);
    }

    public async Task<Tuple<string, string>?> GetCredentials()
    {
        var subdomain = await SecureStorage.GetAsync("subdomain");
        var apiToken = await SecureStorage.GetAsync("apiToken");

        if (string.IsNullOrEmpty(subdomain) || string.IsNullOrEmpty(apiToken))
        {
            SecureStorage.RemoveAll();

            return null;
        }

        return new Tuple<string, string>(subdomain, apiToken);
    }

    public async Task Logout()
    {
        SecureStorage.RemoveAll();

        _user = null;
    }
}