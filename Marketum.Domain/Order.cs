using System;
using System.Collections.Generic;

namespace Marketum.Domain
{
    /// <summary>
    /// Representa uma encomenda no sistema.
    /// </summary>
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public decimal TotalAmount => CalculateTotal();

        private decimal CalculateTotal()
        {
            decimal total = 0;
            foreach (var item in Items)
            {
                total += item.Quantity * item.Price;
            }
            return total;
        }
    }

    /// <summary>
    /// Representa um item de uma encomenda.
    /// </summary>
    public class OrderItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
