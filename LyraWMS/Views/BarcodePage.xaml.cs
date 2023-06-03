using System.Windows.Input;
#if IOS
using BarcodeScanner.Mobile;
#endif

namespace LyraWMS.Views;

public partial class BarcodePage : ContentPage
{
    private readonly ICommand _onBarcodeScannedCommand;
    
    public BarcodePage(ICommand onBarcodeScannedCommand)
    {
        InitializeComponent();

#if IOS
        Task.Run(BarcodeScanner.Mobile.Methods.AskForRequiredPermission);
        BarcodeScanner.Mobile.Methods.SetSupportBarcodeFormat(BarcodeFormats.Code39 | BarcodeFormats.QRCode | BarcodeFormats.Code128);

        var cameraView = new CameraView
        {
            HorizontalOptions = LayoutOptions.FillAndExpand,
            VerticalOptions = LayoutOptions.FillAndExpand,
            TorchOn = false,
            VibrationOnDetected = true,
            ScanInterval = 500
        };
        
        cameraView.OnDetected += OnBarcodeDetected;
        View.Content = cameraView;
#endif
        
        _onBarcodeScannedCommand = onBarcodeScannedCommand;
    }

#if IOS
    private void OnBarcodeDetected(object sender, OnDetectedEventArg e)
    {
        var barcode = e.BarcodeResults;

        if (barcode.Count == 0)
        {
            return;
        }

        _onBarcodeScannedCommand.Execute(barcode[0].DisplayValue);
    }
#endif
}