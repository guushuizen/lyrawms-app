using CommunityToolkit.Mvvm.Messaging;
using LyraWMS.Controls.ViewModels;
using LyraWMS.Messages;
using LyraWMS.Models;

namespace LyraWMS.Controls;

public partial class PickableProduct : ContentView
{
    public static readonly BindableProperty ProductUuidProperty = BindableProperty.Create(nameof(ProductUuid), typeof(string), typeof(PickableProduct));

    public string ProductUuid
    {
        get => (string) GetValue(ProductUuidProperty);
        set => SetValue(ProductUuidProperty, value);
    }
    
    public static readonly BindableProperty ProductQuantityProperty = BindableProperty.Create(nameof(ProductQuantity), typeof(int), typeof(PickableProduct), -1);

    public int ProductQuantity
    {
        get => (int) GetValue(ProductQuantityProperty);
        set => SetValue(ProductQuantityProperty, value);
    }

    private int _pickedQuantity;

    public int PickedQuantity
    {
        get => _pickedQuantity;
        set
        {
            _pickedQuantity = value;
            OnPropertyChanged();
        }
    }

    public PickableProduct()
    {
        InitializeComponent();
        
        WeakReferenceMessenger.Default.Register<ProductPickedMessage>(this, HandleProductPickedMessage);
        WeakReferenceMessenger.Default.Register<ProductUnpickedMessage>(this, HandleProductUnpickedMessage);
    }

    private void HandleProductPickedMessage(object recipient, ProductPickedMessage message)
    {
        if (message.Product.Uuid == ProductUuid)
        {
            if (PickedQuantity < ProductQuantity)
                PickedQuantity += 1;
        }
    }
    
    private void HandleProductUnpickedMessage(object recipient, ProductUnpickedMessage message)
    {
        if (message.Product.Uuid == ProductUuid)
        {
            if (PickedQuantity > 0)
                PickedQuantity -= 1;
        }
    }
}