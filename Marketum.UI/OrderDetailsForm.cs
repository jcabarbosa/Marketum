using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Marketum.Domain;
using Marketum.Services;

namespace Marketum.UI
{
    public partial class OrderDetailsForm : Form
    {
        private readonly Order _order;
        private readonly IClientService _clientService;
        private readonly IProductService _productService;
        private readonly IEmployeeService _employeeService;

        public OrderDetailsForm(Order order, IClientService clientService, IProductService productService, IEmployeeService employeeService)
        {
            InitializeComponent();
            _order = order;
            _clientService = clientService;
            _productService = productService;
            _employeeService = employeeService;
            
            LoadOrderDetails();
        }

        private void LoadOrderDetails()
        {
            try
            {
                // Informações da encomenda
                lblOrderId.Text = $"Encomenda #{_order.Id}";
                lblOrderDate.Text = $"Data: {_order.OrderDate:dd/MM/yyyy HH:mm}";
                lblStatus.Text = $"Estado: {GetStatusDescription(_order.Status)}";
                lblPaymentMethod.Text = $"Pagamento: {GetPaymentMethodDescription(_order.PaymentMethod)}";
                lblTotal.Text = $"Total: {_order.TotalAmount:C}";

                // Informações do cliente
                var client = _clientService.GetById(_order.CustomerId);
                if (client != null)
                {
                    lblClientName.Text = $"Cliente: {client.Name}";
                    lblClientEmail.Text = $"Email: {client.Email}";
                    lblClientPhone.Text = $"Telefone: {client.Phone}";
                    lblClientAddress.Text = $"Morada: {client.Address}";
                }

                // Informações do funcionário
                var employee = _employeeService.GetById(_order.EmployeeId);
                if (employee != null)
                {
                    lblEmployee.Text = $"Funcionário: {employee.Name}";
                }

                // Campanha (se existir)
                if (_order.Campaign != null)
                {
                    lblCampaign.Text = $"Campanha: {_order.Campaign.Name} ({_order.Campaign.DiscountPercentage}% desconto)";
                    lblCampaign.Visible = true;
                }

                // Items da encomenda
                LoadOrderItems();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar detalhes: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadOrderItems()
        {
            try
            {
                var itemsWithDetails = _order.Items.Select(item => {
                    return new {
                        Produto = item.ProductName,
                        Quantidade = item.Quantity,
                        PrecoUnitario = item.Price,
                        Total = item.Quantity * item.Price
                    };
                }).ToList();

                dgvItems.DataSource = itemsWithDetails;
                
                // Aguardar o DataGridView processar os dados
                Application.DoEvents();
                
                // Configurar colunas com verificações mais robustas
                ConfigureColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar items: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void ConfigureColumns()
        {
            try
            {
                if (dgvItems.Columns.Count == 0) return;
                
                foreach (DataGridViewColumn column in dgvItems.Columns)
                {
                    if (column == null) continue;
                    
                    switch (column.Name)
                    {
                        case "Produto":
                            column.HeaderText = "Produto";
                            break;
                        case "Quantidade":
                            column.HeaderText = "Qtd";
                            if (column.Width != 60) // Evitar definir se já está correto
                                column.Width = 60;
                            break;
                        case "PrecoUnitario":
                            column.HeaderText = "Preço Unit.";
                            column.DefaultCellStyle.Format = "C";
                            break;
                        case "Total":
                            column.HeaderText = "Total";
                            column.DefaultCellStyle.Format = "C";
                            break;
                    }
                }
            }
            catch
            {
                // Ignorar erros de configuração de colunas
            }
        }

        private string GetStatusDescription(OrderStatus status)
        {
            return status switch
            {
                OrderStatus.Created => "Criada",
                OrderStatus.Paid => "Paga",
                OrderStatus.Processing => "Em Processamento",
                OrderStatus.Shipped => "Enviada",
                OrderStatus.Completed => "Concluída",
                OrderStatus.Cancelled => "Cancelada",
                _ => status.ToString()
            };
        }

        private string GetPaymentMethodDescription(PaymentMethod method)
        {
            return method switch
            {
                PaymentMethod.Cash => "Dinheiro",
                PaymentMethod.CreditCard => "Cartão Crédito",
                PaymentMethod.BankTransfer => "Transferência",
                PaymentMethod.MbWay => "MB Way",
                PaymentMethod.PayPal => "PayPal",
                PaymentMethod.ApplePay => "Apple Pay",
                _ => method.ToString()
            };
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}