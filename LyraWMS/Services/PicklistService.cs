using System.Net;
using System.Text.Json.Nodes;
using LyraWMS.Models;

namespace LyraWMS.Services;

public class PicklistService
{
    private readonly AuthorizedAPIService _apiService;

    private List<Picklist> _picklists;

    private readonly int ROWS_PER_PAGE = 25;
    
    private int _currentPage = 0;

    public PicklistService(AuthorizedAPIService apiService)
    {
        _apiService = apiService;
        
        _picklists = new List<Picklist>();
    }

    public async Task<List<Picklist>> GetPicklists(bool newPage = false)
    {
        if (!newPage && _currentPage != 0)
        {
            return _picklists.GetRange(_currentPage * ROWS_PER_PAGE, ROWS_PER_PAGE);
        }

        HttpResponseMessage response = await _apiService.GetAsync("/picklists");

        var body = JsonNode.Parse(await response.Content.ReadAsStringAsync());

        List<Picklist> picklists = _apiService.DeserializeJson<List<Picklist>>(body["rows"].ToJsonString());
            
        _picklists.AddRange(picklists);

        return picklists;
    }

    public async Task<Picklist?> FindPicklist(string picklistId)
    {
        Picklist? picklist = _picklists.FirstOrDefault(p => p.Reference == picklistId);

        if (picklist != null)
            return picklist;
        
        HttpResponseMessage response = await _apiService.GetAsync($"/picklists?search={picklistId}");

        var body = JsonNode.Parse(await response.Content.ReadAsStringAsync());

        if (body["rows"].AsArray().Count == 0)
            return null;

        picklist = _apiService.DeserializeJson<Picklist>(body["rows"][0].ToJsonString());
        
        _picklists.Add(picklist);

        return picklist;
    }

    public async Task<FullPicklist?> GetFullPicklist(string picklistUuid)
    {
        HttpResponseMessage response = await _apiService.GetAsync($"/picklist/{picklistUuid}");

        if (response.StatusCode != HttpStatusCode.OK)
        {
            return null;
        }
        
        var body = JsonNode.Parse(await response.Content.ReadAsStringAsync());

        FullPicklist picklist = _apiService.DeserializeJson<FullPicklist>(body["picklist"].ToJsonString());
        
        return picklist;
    }
}