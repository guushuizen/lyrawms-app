using WMS.Services.Interfaces;

namespace WMS.Services;

public class StorageService : IStorageService
{
    public void RemoveAll()
    {
        SecureStorage.RemoveAll();
    }

    public Task SetAsync(string key, string value)
    {
        return SecureStorage.SetAsync(key, value);
    }

    public Task<string> GetAsync(string key)
    {
        return SecureStorage.GetAsync(key);
    }
}
