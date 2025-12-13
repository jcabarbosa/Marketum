using System;
using System.Collections.Generic;

namespace Marketum.Domain
{
    /// <summary>
    /// Representa uma encomenda no sistema
    /// </summary>
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public int EmployeeId { get; set; }

        /// <summary>
        /// Estado atual da encomenda
        /// </summary>
        public OrderStatus Status { get; set; } = OrderStatus.Created;

        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public int? CampaignId { get; set; }
        public Campaign? Campaign { get; set; }

        /// <summary>
        /// Calcula o valor total da encomenda aplicando descontos de campanha se existirem
        /// </summary>
        public decimal TotalAmount => CalculateTotal();

        public void SetStatus(OrderStatus newStatus)
        {
            Status = newStatus;
        }

        private decimal CalculateTotal()
        {
            decimal total = 0;

            foreach (var item in Items)
                total += item.Quantity * item.Price;

            if (Campaign != null)
            {
                decimal discount = total * (Campaign.DiscountPercentage / 100m);
                total -= discount;
            }

            return total;
        }
    }

    /// <summary>
    /// Item individual de uma encomenda
    /// </summary>
    public class OrderItem
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}