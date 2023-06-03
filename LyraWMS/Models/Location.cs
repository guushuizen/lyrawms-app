using System; 
namespace LyraWMS.Models{ 

    public class Location
    {
        public int Id { get; set; }
        public string Uuid { get; set; }
        public int WarehouseId { get; set; }
        public string Reference { get; set; }
        public string Name { get; set; }
        public string Separator { get; set; }
        public object PointId { get; set; }
        public int ParentLocationId { get; set; }
        public object StaticLocationTypeId { get; set; }
        public int DynamicLocationTypeId { get; set; }
        public int Volume { get; set; }
        public int UnlinkIfEmpty { get; set; }
        public int UsedVolume { get; set; }
        public int NotifiesChanges { get; set; }
        public object DeletedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public object DropoffPickupTime { get; set; }
        public object ConfirmPickupDailyAt { get; set; }
        public int ConfirmPickupOnWeekends { get; set; }
        public object VvbTransporterCode { get; set; }
        public string Icon { get; set; }
        public LocationType LocationType { get; set; }
        public DynamicLocationType DynamicLocationType { get; set; }
        public object StaticLocationType { get; set; }
    }

}