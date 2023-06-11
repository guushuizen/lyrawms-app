using System;
using System.Text.Json.Serialization;

namespace LyraWMS.Models
{
    public class ProductLocation
    {
        public int Id { get; set; }
        public string Uuid { get; set; }
        public int ProductId { get; set; }
        public int LocationId { get; set; }
        public int Stock { get; set; }

        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public int ReservedStock { get; set; }
        public int StockThreshold { get; set; }
        public bool Migrated { get; set; }
        public Location Location { get; set; }
    }
}
