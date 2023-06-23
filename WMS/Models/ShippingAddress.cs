using System;

namespace WMS.Models
{
    public class ShippingAddress
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
