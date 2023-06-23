using WMS.Models;

namespace WMS.Services.Interfaces;

public interface IAuthenticationService
{
    public Task<User?> GetCurrentUser();

    public Task<User?> AttemptLogin(string subdomain, string apiToken);

    public Task<Tuple<string, string>?> GetCredentials();

    public void Logout();
}
