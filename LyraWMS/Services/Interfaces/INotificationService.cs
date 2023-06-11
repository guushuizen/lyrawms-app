namespace LyraWMS.Services.Interfaces;

public interface INotificationService
{
    public Task DisplayAlert(string title, string body, string buttonTitle);
    public Task<bool> DisplayAlert(
        string title,
        string body,
        string acceptTitle,
        string declineTitle
    );
    public Task DisplaySnackbar(string body);
}
