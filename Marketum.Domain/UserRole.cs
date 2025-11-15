namespace Marketum.Domain
{
    /// <summary>
    /// Define os níveis de acesso dos funcionários no sistema
    /// </summary>
    public enum UserRole
    {
        Admin,
        Employee,  // funcionario normal
        StockManager,  // getsor de stock
    }
}
