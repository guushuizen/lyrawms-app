using System.Text.Json.Serialization;
namespace LyraWMS.Models;

public class Pivot
{
    [JsonPropertyName("picklist_id")]
    public int PicklistId { get; set; }

    [JsonPropertyName("product_id")]
    public int ProductId { get; set; }

    [JsonPropertyName("amount")]
    public int Amount { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("order_product_id")]
    public string OrderProductId { get; set; }

    [JsonPropertyName("manually_added")]
    public bool ManuallyAdded { get; set; }
}