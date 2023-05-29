using System.Text.Json.Serialization;

namespace LyraWMS.Models;

public class FullPicklist
{
    [JsonPropertyName("id")] public int Id { get; set; }

    [JsonPropertyName("uuid")] public string Uuid { get; set; }

    [JsonPropertyName("assigned_to_user_id")]
    public object AssignedToUserId { get; set; }

    [JsonPropertyName("assigned_to_static_location_id")]
    public object AssignedToStaticLocationId { get; set; }

    [JsonPropertyName("flow_id")] public int FlowId { get; set; }

    [JsonPropertyName("reference")] public string Reference { get; set; }

    [JsonPropertyName("order_id")] public int OrderId { get; set; }

    [JsonPropertyName("shipping_address_id")]
    public int ShippingAddressId { get; set; }

    [JsonPropertyName("billing_address_id")]
    public int BillingAddressId { get; set; }

    [JsonPropertyName("status")] public string Status { get; set; }

    [JsonPropertyName("completed_by")] public object CompletedBy { get; set; }

    [JsonPropertyName("shipped_at")] public object ShippedAt { get; set; }

    [JsonPropertyName("completed_at")] public object CompletedAt { get; set; }

    [JsonPropertyName("snoozed_until")] public object SnoozedUntil { get; set; }

    [JsonPropertyName("snooze_reason")] public object SnoozeReason { get; set; }

    [JsonPropertyName("is_urgent")] public int IsUrgent { get; set; }

    [JsonPropertyName("foreign_order_marked_as_fulfilled_at")]
    public object ForeignOrderMarkedAsFulfilledAt { get; set; }

    [JsonPropertyName("deleted_at")] public object DeletedAt { get; set; }

    [JsonPropertyName("created_at")] public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updated_at")] public DateTime UpdatedAt { get; set; }

    [JsonPropertyName("warehouse_id")] public int WarehouseId { get; set; }

    [JsonPropertyName("shipped_on_sales_channel_at")]
    public object ShippedOnSalesChannelAt { get; set; }

    [JsonPropertyName("error_message")] public object ErrorMessage { get; set; }

    [JsonPropertyName("block_shipping_until")]
    public object BlockShippingUntil { get; set; }

    [JsonPropertyName("expected_shipping_method_id")]
    public object ExpectedShippingMethodId { get; set; }

    [JsonPropertyName("completed")] public bool Completed { get; set; }

    [JsonPropertyName("completed_by_user")]
    public object CompletedByUser { get; set; }

    [JsonPropertyName("manual_products")] public List<object> ManualProducts { get; set; }

    [JsonPropertyName("shipping_address")] public ShippingAddress ShippingAddress { get; set; }

    [JsonPropertyName("billing_address")] public BillingAddress BillingAddress { get; set; }

    [JsonPropertyName("containers")] public List<object> Containers { get; set; }

    [JsonPropertyName("resolution_messages")]
    public List<object> ResolutionMessages { get; set; }

    [JsonPropertyName("expected_shipping_method")]
    public object ExpectedShippingMethod { get; set; }

    [JsonPropertyName("order")] public Order Order { get; set; }

    [JsonPropertyName("products")] public List<Product> Products { get; set; }
}