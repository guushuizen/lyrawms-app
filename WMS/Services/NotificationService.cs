using CommunityToolkit.Maui.Alerts;
using WMS.Services.Interfaces;

namespace WMS.Services;

public class NotificationService : INotificationService
{
    public Task DisplayAlert(string title, string body, string buttonTitle)
    {
        return Shell.Current.DisplayAlert(title, body, buttonTitle);
    }

    public Task<bool> DisplayAlert(
        string title,
        string body,
        string acceptTitle,
        string declineTitle
    )
    {
        return Shell.Current.DisplayAlert(title, body, acceptTitle, declineTitle);
    }

    public Task DisplaySnackbar(string body)
    {
        return Shell.Current.DisplaySnackbar(body);
    }
}
