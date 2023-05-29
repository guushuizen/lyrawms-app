using System.Windows.Input;
using BarcodeScanner.Mobile;

namespace LyraWMS.Views;

public partial class BarcodePage : ContentPage
{
    private readonly ICommand _onBarcodeScannedCommand;
    
    public BarcodePage(ICommand onBarcodeScannedCommand)
    {
        BarcodeScanner.Mobile.Methods.SetSupportBarcodeFormat(BarcodeFormats.Code39 | BarcodeFormats.QRCode | BarcodeFormats.Code128);

        InitializeComponent();

        _onBarcodeScannedCommand = onBarcodeScannedCommand;
    }

    private void OnBarcodeDetected(object sender, OnDetectedEventArg e)
    {
        var barcode = e.BarcodeResults;

        if (barcode.Count == 0)
        {
            return;
        }

        _onBarcodeScannedCommand.Execute(barcode[0].DisplayValue);
    }
}