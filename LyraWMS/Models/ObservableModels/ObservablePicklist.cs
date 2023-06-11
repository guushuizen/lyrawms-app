using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace LyraWMS.Models.ObservableModels;

public class ObservablePicklist : ObservableObject
{
    private readonly FullPicklist _picklist;

    public ObservablePicklist(FullPicklist picklist)
    {
        _picklist = picklist;

        Products = new ObservableCollection<ObservableProduct>(
            _picklist.Products.Select(p => new ObservableProduct(p))
        );
    }

    public ObservableCollection<ObservableProduct> Products { get; }

    public string Reference => _picklist.Reference;
    public ShippingAddress ShippingAddress => _picklist.ShippingAddress;
    public Order Order => _picklist.Order;
    public string Status => _picklist.Status;
    public string Uuid => _picklist.Uuid;
    public int Id => _picklist.Id;
}
