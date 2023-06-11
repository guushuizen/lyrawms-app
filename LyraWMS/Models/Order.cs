using System;

namespace LyraWMS.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Uuid { get; set; }
        public object ParentId { get; set; }
        public int CustomerId { get; set; }
        public int ShippingAddressId { get; set; }
        public int BillingAddressId { get; set; }
        public string Reference { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Customer Customer { get; set; }
        public FulfilmentClient? FulfilmentClient { get; set; }
    }
}
