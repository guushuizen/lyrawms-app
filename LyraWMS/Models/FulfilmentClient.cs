using System.Text.Json.Serialization;

namespace LyraWMS.Models;

public class FulfilmentClient
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("uuid")]
    public string Uuid { get; set; }

    [JsonPropertyName("profile_photo_url")]
    public string ProfilePhotoUrl { get; set; }
}