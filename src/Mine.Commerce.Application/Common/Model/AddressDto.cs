namespace Mine.Commerce.Application.Common
{
    public record AddressDto
    {
        public string City { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public string StreetNo { get; set; }
        public string PostalCode { get; set; }
    }
}
