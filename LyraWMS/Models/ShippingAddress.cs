using System.Text.Json.Serialization;

namespace LyraWMS.Models;

public class ShippingAddress
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("customer_id")]
    public int CustomerId { get; set; }

    [JsonPropertyName("company_name")]
    public object CompanyName { get; set; }

    [JsonPropertyName("fullname")]
    public string Fullname { get; set; }

    [JsonPropertyName("address_line_1")]
    public string AddressLine1 { get; set; }

    [JsonPropertyName("address_line_2")]
    public object AddressLine2 { get; set; }

    [JsonPropertyName("postal_code")]
    public string PostalCode { get; set; }

    [JsonPropertyName("city")]
    public string City { get; set; }

    [JsonPropertyName("country")]
    public string Country { get; set; }

    [JsonPropertyName("validated_at")]
    public string ValidatedAt { get; set; }

    [JsonPropertyName("deleted_at")]
    public object DeletedAt { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }
}