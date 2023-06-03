using System.Net;
using System.Text.Json;
using System.Text.Json.Nodes;
using LyraWMS.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

        List<Picklist> picklists = _apiService.DeserializeJson<List<Picklist>>(
            await response.Content.ReadAsStringAsync(),
            "rows"
        );
            
        _picklists.AddRange(picklists);

        return picklists;
    }

    public async Task<Picklist?> FindPicklist(string picklistId)
    {
        Picklist? picklist = _picklists.FirstOrDefault(p => p.Reference == picklistId);

        if (picklist != null)
            return picklist;
        
        HttpResponseMessage response = await _apiService.GetAsync($"/picklists?search={picklistId}");

        var picklists = _apiService.DeserializeJson<List<Picklist>>(await response.Content.ReadAsStringAsync(), "rows");

        if (picklists.Count == 0)
            return null;
        
        _picklists.Add(picklists.First());

        return picklists.First();
    }

    public async Task<FullPicklist?> GetFullPicklist(string picklistUuid)
    {
        HttpResponseMessage response = await _apiService.GetAsync($"/picklist/{picklistUuid}");

        if (response.StatusCode != HttpStatusCode.OK)
        {
            return null;
        }

        return _apiService.DeserializeJson<FullPicklist>(await response.Content.ReadAsStringAsync(), "picklist");
    }
}