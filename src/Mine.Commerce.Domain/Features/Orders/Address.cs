using System;
using System.ComponentModel.DataAnnotations;

namespace Mine.Commerce.Domain
{
    public class Address
    {
        [Key]
        public Guid Guid { get; set; }
        public Guid CustomerId { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public string StreetNo { get; set; }
        public string PostalCode { get; set; }
    }
}