﻿using WMS.ViewModels;

namespace WMS.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
