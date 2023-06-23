using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.ViewModels.Products;

namespace WMS.Views.Products;

public partial class TransferStockPage : ContentPage
{
    public TransferStockPage(TransferStockViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }
}
