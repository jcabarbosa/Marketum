namespace Marketum.Domain
{
    /// <summary>
    /// Define os níveis de acesso dos funcionários no sistema
    /// </summary>
    public enum UserRole
    {
        Admin = 1,
        Employee = 2,  // funcionario normal
        StockManager = 3,  // getsor de stock
    }
}
