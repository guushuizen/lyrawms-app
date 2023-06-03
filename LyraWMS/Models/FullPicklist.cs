using Newtonsoft.Json;
using System.Collections.Generic;
using System;
namespace LyraWMS.Models;

public class FullPicklist
{
    public int Id { get; set; }
    public string Uuid { get; set; }
    public object AssignedToUserId { get; set; }
    public object AssignedToStaticLocationId { get; set; }
    public int FlowId { get; set; }
    public string Reference { get; set; }
    public int OrderId { get; set; }
    public int ShippingAddressId { get; set; }
    public int BillingAddressId { get; set; }
    public string Status { get; set; }
    public object CompletedBy { get; set; }
    public object ShippedAt { get; set; }
    public object CompletedAt { get; set; }
    public object SnoozedUntil { get; set; }
    public object SnoozeReason { get; set; }
    public int IsUrgent { get; set; }
    public object ForeignOrderMarkedAsFulfilledAt { get; set; }
    public object DeletedAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int WarehouseId { get; set; }
    public object ShippedOnSalesChannelAt { get; set; }
    public object ErrorMessage { get; set; }
    public object BlockShippingUntil { get; set; }
    public int ExpectedShippingMethodId { get; set; }
    public object WeighedWeight { get; set; }
    public object DropoffPoint { get; set; }
    public bool Completed { get; set; }
    public object CompletedByUser { get; set; }
    public List<Product> Products { get; set; }
    public List<object> ManualProducts { get; set; }
    public Order Order { get; set; }
    public ShippingAddress ShippingAddress { get; set; }
    public BillingAddress BillingAddress { get; set; }
    public List<object> Notes { get; set; }
    public List<object> Shipments { get; set; }
    public List<object> Containers { get; set; }
    public List<object> ResolutionMessages { get; set; }
    public List<object> Batch { get; set; }

}