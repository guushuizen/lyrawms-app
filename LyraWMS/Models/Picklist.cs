using System.Collections.Generic; 
using System; 
namespace LyraWMS.Models;

public class Picklist
{
    public int Id { get; set; }
    public string Uuid { get; set; }
    public int IsUrgent { get; set; }
    public object DeletedAt { get; set; }
    public int HasNotes { get; set; }
    public string Reference { get; set; }
    public string Status { get; set; }
    public object SalesChannelReference { get; set; }
    public object SalesChannel { get; set; }

    public DateTime CreatedAt { get; set; }
    public string Customer { get; set; }
    public string CompletedAt { get; set; }
    public string ShippedAt { get; set; }
    public object VvbTransporterCode { get; set; }
    public string ExpectedShippingDate { get; set; }
    public int ShippingMethod { get; set; }
    public string ShippingMethodName { get; set; }
    public string CourierName { get; set; }
    public int ShippingMethodId { get; set; }
    public int CourierId { get; set; }
    public string OrderReference { get; set; }
    public string OrderUuid { get; set; }
    public string FulfilmentClient { get; set; }
    public object CompletedByUser { get; set; }
}