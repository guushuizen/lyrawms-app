using System;

namespace WMS.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Uuid { get; set; }
        public string Reference { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public FulfilmentClient? FulfilmentClient { get; set; }
    }
}
