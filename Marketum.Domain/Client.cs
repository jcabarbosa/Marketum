namespace Marketum.Domain
{
    /// <summary>
    /// Representa um cliente no sistema.
    /// </summary>
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int TaxNr { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}
