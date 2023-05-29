using CommunityToolkit.Mvvm.Messaging.Messages;
using LyraWMS.Models;

namespace LyraWMS.Messages;

public class ProductUnpickedMessage : ValueChangedMessage<Product>
{
    public Product Product { get; }
    
    public ProductUnpickedMessage(Product value) : base(value)
    {
        Product = value;
    }
}