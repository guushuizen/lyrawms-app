using System.Text.Json.Serialization;

namespace LyraWMS.Models;

public class Order
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("uuid")]
    public string Uuid { get; set; }

    [JsonPropertyName("parent_id")]
    public object ParentId { get; set; }

    [JsonPropertyName("fulfilment_client_id")]
    public int FulfilmentClientId { get; set; }

    [JsonPropertyName("customer_id")]
    public int CustomerId { get; set; }

    [JsonPropertyName("shipping_address_id")]
    public int ShippingAddressId { get; set; }

    [JsonPropertyName("billing_address_id")]
    public int BillingAddressId { get; set; }

    [JsonPropertyName("reference")]
    public string Reference { get; set; }

    [JsonPropertyName("sales_channel_id")]
    public object SalesChannelId { get; set; }

    [JsonPropertyName("saleschannel_foreign_order_id")]
    public object SaleschannelForeignOrderId { get; set; }

    [JsonPropertyName("saleschannel_foreign_order_reference")]
    public object SaleschannelForeignOrderReference { get; set; }

    [JsonPropertyName("saleschannel_foreign_order_required_courier_type")]
    public object SaleschannelForeignOrderRequiredCourierType { get; set; }

    [JsonPropertyName("saleschannel_foreign_order_additional_data")]
    public object SaleschannelForeignOrderAdditionalData { get; set; }

    [JsonPropertyName("is_gift")]
    public bool IsGift { get; set; }

    [JsonPropertyName("sunday_delivery")]
    public bool SundayDelivery { get; set; }

    [JsonPropertyName("evening_delivery")]
    public bool EveningDelivery { get; set; }

    [JsonPropertyName("prefers_same_day_delivery")]
    public bool PrefersSameDayDelivery { get; set; }

    [JsonPropertyName("courier_id")]
    public object CourierId { get; set; }

    [JsonPropertyName("shipping_method_id")]
    public object ShippingMethodId { get; set; }

    [JsonPropertyName("accepts_returns")]
    public int AcceptsReturns { get; set; }

    [JsonPropertyName("is_b2b_order")]
    public bool IsB2bOrder { get; set; }

    [JsonPropertyName("transporters")]
    public object Transporters { get; set; }

    [JsonPropertyName("sender_instructions")]
    public object SenderInstructions { get; set; }

    [JsonPropertyName("special_agreements")]
    public object SpecialAgreements { get; set; }

    [JsonPropertyName("franco")]
    public int Franco { get; set; }

    [JsonPropertyName("repayment_agreement")]
    public object RepaymentAgreement { get; set; }

    [JsonPropertyName("cmr_attatched_documents")]
    public object CmrAttatchedDocuments { get; set; }

    [JsonPropertyName("is_urgent")]
    public int IsUrgent { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("ordered_at")]
    public string OrderedAt { get; set; }

    [JsonPropertyName("snoozed_until")]
    public object SnoozedUntil { get; set; }

    [JsonPropertyName("snooze_reason")]
    public object SnoozeReason { get; set; }

    [JsonPropertyName("paused_at")]
    public object PausedAt { get; set; }

    [JsonPropertyName("paused_reason")]
    public object PausedReason { get; set; }

    [JsonPropertyName("expected_shipping_date")]
    public string ExpectedShippingDate { get; set; }

    [JsonPropertyName("shipped_at")]
    public object ShippedAt { get; set; }

    [JsonPropertyName("editing_started_at")]
    public object EditingStartedAt { get; set; }

    [JsonPropertyName("deleted_at")]
    public object DeletedAt { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [JsonPropertyName("is_vvb_order")]
    public int IsVvbOrder { get; set; }

    [JsonPropertyName("vvb_transporter_code")]
    public object VvbTransporterCode { get; set; }

    [JsonPropertyName("return_order_id")]
    public object ReturnOrderId { get; set; }

    [JsonPropertyName("extra_fields")]
    public object ExtraFields { get; set; }

    [JsonPropertyName("lang")]
    public string Lang { get; set; }

    [JsonPropertyName("deletion_reason")]
    public object DeletionReason { get; set; }

    [JsonPropertyName("is_concept")]
    public bool IsConcept { get; set; }

    [JsonPropertyName("customer")]
    public Customer Customer { get; set; }

    [JsonPropertyName("fulfilment_client")]
    public FulfilmentClient FulfilmentClient { get; set; }

    [JsonPropertyName("sales_channel")]
    public object SalesChannel { get; set; }
}