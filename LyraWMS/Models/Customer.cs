using System; 
namespace LyraWMS.Models{ 

    public class Customer
    {
        public int Id { get; set; }
        public object FulfilmentClientId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public object PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}