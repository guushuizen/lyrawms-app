using System.Collections.ObjectModel;
using System.Windows.Input;
using LyraWMS.Models;
using LyraWMS.Services;
using LyraWMS.Views.Products;
using Location = LyraWMS.Models.Location;

namespace LyraWMS.ViewModels.Products;

[QueryProperty(nameof(Product), "Product")]
public class TransferStockViewModel : BaseViewModel
{
    private Product _product;

    public Product Product
    {
        get => _product;
        set => SetProperty(ref _product, value);
    }

    private ProductLocation _oldProductLocation;

    public ProductLocation OldProductLocation
    {
        get => _oldProductLocation;
        set => SetProperty(ref _oldProductLocation, value);
    }

    private int _quantityToMove;

    public int QuantityToMove
    {
        get => _quantityToMove;
        set => SetProperty(ref _quantityToMove, value);
    }

    private Location? _newLocation;

    public Location? NewLocation
    {
        get => _newLocation;
        set => SetProperty(ref _newLocation, value);
    }

    private ObservableCollection<Warehouse> _availableWarehouses;

    public ObservableCollection<Warehouse> AvailableWarehouses
    {
        get => _availableWarehouses;
        set => SetProperty(ref _availableWarehouses, value);
    }

    private Warehouse _selectedWarehouse;

    public Warehouse SelectedWarehouse
    {
        get => _selectedWarehouse;
        set => SetProperty(ref _selectedWarehouse, value);
    }

    private ObservableCollection<Location> _availableLocations;

    public ObservableCollection<Location> AvailableLocations
    {
        get => _availableLocations;
        set => SetProperty(ref _availableLocations, value);
    }

    private string _searchQuery;

    public string SearchQuery
    {
        get => _searchQuery;
        set => SetProperty(ref _searchQuery, value);
    }

    private bool _isLoadingLocations;

    public bool IsLoadingLocations
    {
        get => _isLoadingLocations;
        set => SetProperty(ref _isLoadingLocations, value);
    }

    public ICommand MoveStockCommand { get; set; }

    private ProductService _productService;

    public TransferStockViewModel(ProductService productService)
    {
        _productService = productService;

        AvailableWarehouses = new ObservableCollection<Warehouse>();
        AvailableLocations = new ObservableCollection<Location>();

        Loading = true;
        IsLoadingLocations = true;

        MoveStockCommand = new Command(async () => await MoveStock());

        PropertyChanged += (sender, args) =>
        {
            if (args.PropertyName == nameof(Product))
                Task.Run(LoadAvailableWarehouses);
        };
        PropertyChanged += (sender, args) =>
        {
            if (args.PropertyName == nameof(SelectedWarehouse))
                Task.Run(LoadLocations);
        };
        PropertyChanged += (sender, args) =>
        {
            if (args.PropertyName == nameof(SearchQuery))
                Task.Run(LoadLocations);
        };
    }

    private async Task LoadAvailableWarehouses()
    {
        var warehouses = await _productService.GetWarehouses();

        MainThread.BeginInvokeOnMainThread(() =>
        {
            warehouses.ForEach(w => AvailableWarehouses.Add(w));

            Loading = false;
        });
    }

    private async Task LoadLocations()
    {
        IsLoadingLocations = true;

        (await _productService.GetAvailableLocations(Product, SelectedWarehouse)).ForEach(
            l => AvailableLocations.Add(l)
        );

        IsLoadingLocations = false;
    }

    private async Task MoveStock()
    {
        if (QuantityToMove == 0)
        {
            await Shell.Current.DisplayAlert(
                "Oops",
                "Er moet een te verplaatsen hoeveelheid ingevuld zijn! Deze kan niet 0 zijn.",
                "OK"
            );
            return;
        }

        if (OldProductLocation == null)
        {
            await Shell.Current.DisplayAlert(
                "Oops",
                "Er is nog geen oude locatie ingevuld waar de voorraad vandaan verplaatst moet worden.",
                "OK"
            );
            return;
        }

        //if (await _productService.MoveStock(Product, QuantityToMove, NewLocation, OldProductLocation))
        if (true)
        {
            await Shell.Current.GoToAsync(
                "..",
                new Dictionary<string, object> { { "ShouldRefresh", true } }
            );
        }
        else
        {
            await Shell.Current.DisplayAlert(
                "Oops",
                "Er is iets niet goed gegaan! Probeer het later nog eens,",
                "OK"
            );
        }
    }
}
