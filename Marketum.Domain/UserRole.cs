namespace Marketum.Domain
{
    /// <summary>
    /// Define os níveis de acesso dos funcionários no sistema.
    /// </summary>
    public enum UserRole
    {
        Admin = 0,
        Employee = 1, // Funcionário
        StockManager = 2 // Gestor de Stock
    }
}
