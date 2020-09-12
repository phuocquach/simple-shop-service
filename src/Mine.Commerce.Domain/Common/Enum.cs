namespace Mine.Commerce.Domain.Common
{
    
    public enum OrderStatus : int
    {
        Draft = 1,
        Submited = 2,
        Processing = 3,
        Delivering = 4,
        Completed = 5,
    }
}