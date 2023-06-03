using System; 
namespace LyraWMS.Models{ 

    public class DynamicLocationType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AllowsPicking { get; set; }
        public int HasPriority { get; set; }
        public object ProductsLimit { get; set; }
        public int TakesUnlimitedStock { get; set; }
        public int LogsChanges { get; set; }
        public int UnlinksIfEmpty { get; set; }
        public int StockThresholdPercentage { get; set; }
        public object DeletedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}