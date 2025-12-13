namespace Marketum.Domain
{
    /// <summary>
    /// Estados possiveis de uma encomenda
    /// </summary>
    public enum OrderStatus
    {
        Created = 0,
        Paid = 1,
        Processing = 2,
        Shipped = 3,
        Completed = 4,
        Cancelled = 5
    }
}
