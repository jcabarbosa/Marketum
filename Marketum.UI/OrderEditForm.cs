using System;
using System.Windows.Forms;
using Marketum.Domain;
using Marketum.Services;

namespace Marketum.UI
{
    public partial class OrderEditForm : Form
    {
        private readonly IOrderService _orderService;
        private readonly Order _order;

        public OrderEditForm(IOrderService orderService, Order order)
        {
            InitializeComponent();
            _orderService = orderService;
            _order = order;
        }

        private void OrderEditForm_Load(object sender, EventArgs e)
        {
            lblOrderId.Text = $"Encomenda #{_order.Id}";
            lblCustomer.Text = $"Cliente: {_order.CustomerId}";
            lblDate.Text = $"Data: {_order.OrderDate:dd/MM/yyyy HH:mm}";
            lblTotal.Text = $"Total: {_order.TotalAmount:C}";
            
            cmbStatus.DataSource = Enum.GetValues(typeof(OrderStatus));
            cmbStatus.SelectedItem = _order.Status;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var newStatus = (OrderStatus)cmbStatus.SelectedItem;
                
                switch (newStatus)
                {
                    case OrderStatus.Processing:
                        _orderService.ConfirmOrder(_order.Id);
                        break;
                    case OrderStatus.Paid:
                        _orderService.MarkAsPaid(_order.Id);
                        break;
                    case OrderStatus.Shipped:
                        _orderService.ShipOrder(_order.Id);
                        break;
                    case OrderStatus.Completed:
                        _orderService.CompleteOrder(_order.Id);
                        break;
                    case OrderStatus.Cancelled:
                        _orderService.CancelOrder(_order.Id);
                        break;
                }
                
                MessageBox.Show("Encomenda atualizada com sucesso!", "Sucesso");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}