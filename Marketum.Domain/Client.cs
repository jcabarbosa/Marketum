namespace Marketum.Domain
{
    /// <summary>
    /// Representa um cliente no sistema.
    /// </summary>
    public class Client : Person
    {
        public override string GetContactSummary()
        {
            return $"Cliente: {Name}, Email: {Email}, Telefone: {Phone}";
        }
    }
}
