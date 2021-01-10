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

    public enum CartStatus : int 
    {
        Empty = 0,
        Buying = 1,
        CheckingOut = 2,
        CheckedOut = 3
    }
}