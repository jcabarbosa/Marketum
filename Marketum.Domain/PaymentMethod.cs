namespace Marketum.Domain
{
    /// <summary>
    /// Define os métodos de pagamento disponíveis
    /// </summary>
    public enum PaymentMethod
    {
        Cash = 0,
        CreditCard = 1,
        BankTransfer = 2,
        MbWay = 3,
        PayPal = 4,
        ApplePay = 5,
    }
}
