using System;

namespace Marketum.Domain
{
    /// <summary>
    /// Representa uma campanha promocional
    /// </summary>
    public class Campaign
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal DiscountPercentage { get; set; }
    }
}
