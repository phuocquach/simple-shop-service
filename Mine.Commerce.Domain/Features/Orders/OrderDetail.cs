using System;
using System.ComponentModel.DataAnnotations;

namespace Mine.Commerce.Domain
{
    public class OrderDetail
    {
        [Key]
        public Guid Guid { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public long Amount { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice { get; set; }
    }
}