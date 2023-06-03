using System; 
namespace LyraWMS.Models{ 

    public class ProductLocation
    {
        public int Id { get; set; }
        public string Uuid { get; set; }
        public int ProductId { get; set; }
        public int LocationId { get; set; }
        public int Stock { get; set; }
        public string ReservedStock { get; set; }
        public int StockThreshold { get; set; }
        public object DeletedAt { get; set; }
        public object CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Migrated { get; set; }
        public Location Location { get; set; }
    }

}