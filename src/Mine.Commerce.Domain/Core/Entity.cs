using System;
using System.ComponentModel.DataAnnotations;

namespace Mine.Commerce.Domain
{
    public abstract class Entity
    {
        [Key]
        public Guid Guid { get; set; }
        public int Id { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public DateTime UpdatedDateUtc { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
