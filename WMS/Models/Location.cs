using System;

namespace WMS.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Uuid { get; set; }
        public int WarehouseId { get; set; }
        public string Name { get; set; }
    }
}
