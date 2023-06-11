using System;
using System.Text.Json.Serialization;

namespace LyraWMS.Models
{
    public class ProductLocation
    {
        public int Id { get; set; }
        public string Uuid { get; set; }
        public int Stock { get; set; }
        public Location Location { get; set; }
    }
}
