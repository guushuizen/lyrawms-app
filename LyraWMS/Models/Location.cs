using System;
using System.Text.Json.Serialization;

namespace LyraWMS.Models{ 

    public class Location
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("uuid")]
        public string Uuid { get; set; }

        [JsonPropertyName("warehouse_id")]
        public int WarehouseId { get; set; }

        [JsonPropertyName("reference")]
        public string Reference { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("separator")]
        public string Separator { get; set; }

        [JsonPropertyName("point_id")]
        public object PointId { get; set; }

        [JsonPropertyName("parent_location_id")]
        public int ParentLocationId { get; set; }

        [JsonPropertyName("static_location_type_id")]
        public object StaticLocationTypeId { get; set; }

        [JsonPropertyName("dynamic_location_type_id")]
        public int DynamicLocationTypeId { get; set; }

        [JsonPropertyName("volume")]
        public int Volume { get; set; }

        [JsonPropertyName("unlink_if_empty")]
        public int UnlinkIfEmpty { get; set; }

        [JsonPropertyName("used_volume")]
        public int UsedVolume { get; set; }

        [JsonPropertyName("notifies_changes")]
        public int NotifiesChanges { get; set; }

        [JsonPropertyName("deleted_at")]
        public object DeletedAt { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("dropoff_pickup_time")]
        public object DropoffPickupTime { get; set; }

        [JsonPropertyName("confirm_pickup_daily_at")]
        public object ConfirmPickupDailyAt { get; set; }

        [JsonPropertyName("confirm_pickup_on_weekends")]
        public int ConfirmPickupOnWeekends { get; set; }

        [JsonPropertyName("vvb_transporter_code")]
        public object VvbTransporterCode { get; set; }

        [JsonPropertyName("icon")]
        public string Icon { get; set; }

        [JsonPropertyName("location_type")]
        public LocationType LocationType { get; set; }

        [JsonPropertyName("dynamic_location_type")]
        public DynamicLocationType DynamicLocationType { get; set; }

        [JsonPropertyName("static_location_type")]
        public object StaticLocationType { get; set; }
    }

}