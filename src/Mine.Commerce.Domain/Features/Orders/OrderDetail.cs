using System;
using System.ComponentModel.DataAnnotations;

namespace Mine.Commerce.Domain
{
    public class OrderItem
    {
        [Key]
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public long Amount { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice { get; set; }
    }
}