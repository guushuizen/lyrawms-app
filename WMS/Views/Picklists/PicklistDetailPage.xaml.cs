using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.ViewModels.Picklists;

namespace WMS.Views.Picklists;

public partial class PicklistDetailPage : ContentPage
{
    public PicklistDetailPage(PicklistDetailViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }
}
