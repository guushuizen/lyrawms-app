using System.Text.Json.Serialization;

namespace LyraWMS.Models;

public class DynamicLocationType
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("allows_picking")]
    public int AllowsPicking { get; set; }

    [JsonPropertyName("has_priority")]
    public int HasPriority { get; set; }

    [JsonPropertyName("products_limit")]
    public object ProductsLimit { get; set; }

    [JsonPropertyName("takes_unlimited_stock")]
    public int TakesUnlimitedStock { get; set; }

    [JsonPropertyName("logs_changes")]
    public int LogsChanges { get; set; }

    [JsonPropertyName("unlinks_if_empty")]
    public int UnlinksIfEmpty { get; set; }

    [JsonPropertyName("stock_threshold_percentage")]
    public int StockThresholdPercentage { get; set; }

    [JsonPropertyName("deleted_at")]
    public object DeletedAt { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }
}