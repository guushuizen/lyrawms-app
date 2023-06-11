namespace LyraWMS.Services.Interfaces;

public interface IStorageService
{
    public void RemoveAll();

    public Task SetAsync(string key, string value);

    public Task<string> GetAsync(string key);
}