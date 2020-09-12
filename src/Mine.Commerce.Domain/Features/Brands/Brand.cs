using System;

namespace Mine.Commerce.Domain
{
    public class Brand : Entity
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public static Brand Create (string name, string country)
        {
            return new Brand
            {
                Id = Guid.NewGuid(),
                Name = name,
                Country = country
            };
        }
    }
}
