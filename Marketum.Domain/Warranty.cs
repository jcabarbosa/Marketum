namespace Marketum.Domain
{
    /// <summary>
    /// Representa um template de garantia que pode ser aplicado a produtos
    /// </summary>
    public class Warranty
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int DurationMonths { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}