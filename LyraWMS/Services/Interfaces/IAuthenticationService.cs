using LyraWMS.Models;

namespace LyraWMS.Services.Interfaces;

public interface IAuthenticationService
{
    public Task<User?> GetCurrentUser();

    public Task<User?> AttemptLogin(string subdomain, string apiToken);

    public Task<Tuple<string, string>?> GetCredentials();

    public void Logout();
}
