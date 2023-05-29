using System.Text.Json.Serialization;

namespace LyraWMS.Models;

public class ProductLocation
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("uuid")]
    public string Uuid { get; set; }

    [JsonPropertyName("product_id")]
    public int ProductId { get; set; }

    [JsonPropertyName("location_id")]
    public int LocationId { get; set; }

    [JsonPropertyName("stock")]
    public int Stock { get; set; }

    [JsonPropertyName("reserved_stock")]
    public string ReservedStock { get; set; }

    [JsonPropertyName("stock_threshold")]
    public int StockThreshold { get; set; }

    [JsonPropertyName("deleted_at")]
    public object DeletedAt { get; set; }

    [JsonPropertyName("created_at")]
    public object CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [JsonPropertyName("migrated")]
    public bool Migrated { get; set; }

    [JsonPropertyName("location")]
    public Location Location { get; set; }
}