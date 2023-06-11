using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using JorgeSerrano.Json;
using LyraWMS.Models;

namespace LyraWMS.Services;

public class AuthorizedAPIService
{
    private readonly AuthenticationService _authenticationService;

    private HttpClient _httpClient;

    public AuthorizedAPIService(AuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    private async Task InitializeClient()
    {
        _httpClient = new HttpClient(new HttpClientHandler { AllowAutoRedirect = false });

        var credentials = await _authenticationService.GetCredentials();

        var (subdomain, apiToken) = credentials;

        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiToken}");
        _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        _httpClient.BaseAddress = new Uri($"https://{subdomain}.wms.nl/");
    }

    public async Task<HttpResponseMessage> GetAsync(string uri)
    {
        await InitializeClient();

        HttpResponseMessage response = await _httpClient.GetAsync(uri);

        await AssertAuthSuccess(response);

        return response;
    }

    public async Task<HttpResponseMessage> PostAsync(
        string uri,
        Dictionary<string, object> jsonContent
    )
    {
        await InitializeClient();

        HttpResponseMessage response = await _httpClient.PostAsJsonAsync(uri, jsonContent);

        await AssertAuthSuccess(response);

        return response;
    }

    public async Task<HttpResponseMessage> PutAsync(
        string uri,
        Dictionary<string, string> jsonContent = null
    )
    {
        await InitializeClient();

        HttpResponseMessage response = await _httpClient.PutAsJsonAsync(uri, jsonContent);

        await AssertAuthSuccess(response);

        return response;
    }

    public TValue DeserializeJson<TValue>(string jsonObject, string? rootKey = null)
    {
        string jsonToDeserialize = jsonObject;
        if (rootKey != null)
        {
            JsonNode node = JsonNode.Parse(jsonToDeserialize);
            jsonToDeserialize = node[rootKey].ToString();
        }

        return JsonSerializer.Deserialize<TValue>(
            jsonToDeserialize,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = new JsonSnakeCaseNamingPolicy(),
            }
        );
    }

    private async Task AssertAuthSuccess(HttpResponseMessage response)
    {
        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            await _authenticationService.Logout();
        }
    }
}
