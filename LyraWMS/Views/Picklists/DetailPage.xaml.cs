using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LyraWMS.ViewModels.Picklists;

namespace LyraWMS.Views.Picklists;

public partial class DetailPage : ContentPage
{
    public DetailPage(DetailViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }
}