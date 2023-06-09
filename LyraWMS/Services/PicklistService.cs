using System.Net;
using System.Text.Json;
using System.Text.Json.Nodes;
using LyraWMS.Models;
using LyraWMS.Models.ObservableModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LyraWMS.Services;

public class PicklistService
{
    private readonly AuthorizedAPIService _apiService;

    public PicklistService(AuthorizedAPIService apiService)
    {
        _apiService = apiService;
    }

    public async Task<List<Picklist>> GetPicklists(int page = 0)
    {
        HttpResponseMessage response = await _apiService.GetAsync($"/picklists?modifiers[filters][status]=open&page={page}");

        List<Picklist> picklists = _apiService.DeserializeJson<List<Picklist>>(
            await response.Content.ReadAsStringAsync(),
            "rows"
        );
            
        return picklists;
    }

    public async Task<Picklist?> FindPicklist(string picklistId)
    {
        HttpResponseMessage response = await _apiService.GetAsync($"/picklists?search={picklistId}");

        var picklists = _apiService.DeserializeJson<List<Picklist>>(await response.Content.ReadAsStringAsync(), "rows");

        if (picklists.Count == 0)
            return null;

        return picklists.First();
    }

    public async Task<FullPicklist?> GetFullPicklist(string picklistUuid)
    {
        HttpResponseMessage response = await _apiService.GetAsync($"/picklist/{picklistUuid}");

        if (response.StatusCode != HttpStatusCode.OK)
        {
            return null;
        }

        var content = await response.Content.ReadAsStringAsync();

        return _apiService.DeserializeJson<FullPicklist>(content, "picklist");
    }

    public async Task<bool> CompletePicklist(ObservablePicklist fullPicklist)
    {
        HttpResponseMessage response = await _apiService.PutAsync($"/picklist/{fullPicklist.Id}/complete-current-stage");

        return response.IsSuccessStatusCode;
    }
}