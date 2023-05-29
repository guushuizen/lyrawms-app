using LyraWMS.ViewModels;

namespace LyraWMS.Views;

public partial class LoginPage : ContentPage
{
    
    public LoginPage(LoginPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}