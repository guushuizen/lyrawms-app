using Newtonsoft.Json;
using System.Collections.Generic;
using System;
namespace LyraWMS.Models;

public class FullPicklist
{
    public int Id { get; set; }
    public string Uuid { get; set; }
    public string Reference { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool Completed { get; set; }
    public List<Product> Products { get; set; }
    public Order Order { get; set; }
    public ShippingAddress ShippingAddress { get; set; }
    public BillingAddress BillingAddress { get; set; }

}