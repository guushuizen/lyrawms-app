using CommunityToolkit.Mvvm.Messaging.Messages;
using LyraWMS.Models;

namespace LyraWMS.Messages;

public class ProductPickedMessage : ValueChangedMessage<Product>
{
    public Product Product { get; }
    
    public ProductPickedMessage(Product value) : base(value)
    {
        Product = value;
    }
}