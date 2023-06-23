using System.ComponentModel;
using System.Windows.Input;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.Input;
using WMS.Models;
using WMS.Models.ObservableModels;
using WMS.Services;
using WMS.Services.Interfaces;
using WMS.Views;

namespace WMS.ViewModels.Picklists;

[QueryProperty(nameof(Picklist), "Picklist")]
public class PicklistDetailViewModel : BaseViewModel
{
    private ObservablePicklist _fullPicklist;
    public ObservablePicklist FullPicklist
    {
        get => _fullPicklist;
        private set => SetProperty(ref _fullPicklist, value);
    }

    private Picklist _picklist;
    public Picklist Picklist
    {
        get => _picklist;
        set => SetProperty(ref _picklist, value);
    }

    private readonly PicklistService _picklistService;

    private readonly INotificationService _notificationService;

    private bool _isPicklistReady;
    public bool IsPicklistReady
    {
        get => _isPicklistReady;
        set => SetProperty(ref _isPicklistReady, value);
    }

    public ICommand OpenBarcodePopupCommand { get; set; }
    public ICommand DecreasePickedProductQuantityCommand { get; set; }
    public ICommand IncreasePickedProductQuantityCommand { get; set; }

    public ICommand CompletePicklistCommand { get; set; }

    public PicklistDetailViewModel(
        PicklistService picklistService,
        INotificationService notificationService
    )
    {
        Loading = true;

        _picklistService = picklistService;
        _notificationService = notificationService;

        OpenBarcodePopupCommand = new Command(async () => await OpenBarcodePopup());

        DecreasePickedProductQuantityCommand = new Command(
            sku => DecreasePickedProductQuantity((string)sku)
        );
        IncreasePickedProductQuantityCommand = new Command(
            sku => IncreasePickedProductQuantity((string)sku)
        );
        CompletePicklistCommand = new AsyncRelayCommand(async () => await CompletePicklist());

        PropertyChanged += Initialize;
    }

    private void DeterminePicklistReadiness()
    {
        IsPicklistReady = FullPicklist.Products.All(p => p.PickedQuantity == p.PickableQuantity);
    }

    private async void Initialize(object? sender, PropertyChangedEventArgs args)
    {
        if (args.PropertyName == nameof(Picklist) && Picklist.Reference != FullPicklist?.Reference)
        {
            FullPicklist = new ObservablePicklist(
                await _picklistService.GetFullPicklist(Picklist.Uuid)
            );

            Loading = false;
        }
    }

    private async Task OpenBarcodePopup()
    {
        await Application.Current.MainPage.Navigation.PushModalAsync(
            new BarcodePage(new Command(async (barcode) => await OnBarcodeScanned((string)barcode)))
        );
    }

    private void DecreasePickedProductQuantity(string barcode)
    {
        ObservableProduct? product = FullPicklist.Products.FirstOrDefault(p => p.Sku == barcode);

        if (product != null && product.PickedQuantity > 0)
        {
            FullPicklist.Products.First(p => p.Sku == barcode).PickedQuantity--;
            DeterminePicklistReadiness();
        }
    }

    private void IncreasePickedProductQuantity(string barcode)
    {
        ObservableProduct? product = FullPicklist.Products.FirstOrDefault(p => p.Sku == barcode);

        if (product != null && product.PickedQuantity < product.PickableQuantity)
        {
            FullPicklist.Products.First(p => p.Sku == barcode).PickedQuantity++;
            DeterminePicklistReadiness();
        }
        else
        {
            _notificationService.DisplayAlert(
                "Oops",
                "Deze SKU kon niet gevonden worden op deze picklijst. Heb je het juiste product gepakt?",
                "OK"
            );
        }
    }

    private async Task OnBarcodeScanned(string sku)
    {
        IncreasePickedProductQuantity(sku);

        await Application.Current.MainPage.Navigation.PopModalAsync();
    }

    private async Task CompletePicklist()
    {
        var result = await _notificationService.DisplayAlert(
            "Weet je het zeker?",
            "Je staat op het punt deze picklijst af te ronden.",
            "Ja",
            "Nee"
        );

        if (!result)
            return;

        if (await _picklistService.CompletePicklist(FullPicklist))
        {
            await Shell.Current.GoToAsync("..");

            await _notificationService.DisplaySnackbar(
                $"Picklijst {FullPicklist.Reference} is afgerond!"
            );
        }
        else
        {
            await _notificationService.DisplayAlert(
                "Oops",
                "Er is iets fout gegaan tijdens het afronden van de picklijst. Probeer het later nogmaals of neem anders contact op met LyraWMS",
                "OK"
            );
        }
    }
}
