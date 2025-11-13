namespace Marketum.Domain
{
    /// <summary>
    /// Representa uma garantia associada a um produto.
    /// </summary>
    public class Warranty
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int DurationMonths { get; set; }
        public string Terms { get; set; } = string.Empty;   
    }
}
