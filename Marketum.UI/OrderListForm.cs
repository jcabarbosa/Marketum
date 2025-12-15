using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Marketum.Domain;
using Marketum.Services;

namespace Marketum.UI
{
    public partial class OrderListForm : Form
    {
        private readonly IOrderService _orderService;

        private readonly IClientService _clientService;
        private readonly IProductService _productService;
        private readonly IEmployeeService _employeeService;
        
        public OrderListForm(IOrderService orderService, IClientService clientService = null, IProductService productService = null, IEmployeeService employeeService = null)
        {
            InitializeComponent();
            _orderService = orderService;
            _clientService = clientService;
            _productService = productService;
            _employeeService = employeeService;
        }

        private void OrderListForm_Load(object sender, EventArgs e)
        {
            LoadOrders();
            
            // Configurar double-click para editar
            dgvOrders.DoubleClick += (s, e) => btnEdit_Click(s, e);
            
            // Configurar atalhos de teclado
            dgvOrders.KeyDown += DgvOrders_KeyDown;
        }

        private void LoadOrders()
        {
            try
            {
                dgvOrders.DataSource = null;
                var orders = _orderService.GetAllOrders();
                
                var ordersWithDetails = orders.Select(o => new {
                    o.Id,
                    Cliente = o.CustomerId,
                    Data = o.OrderDate,
                    Status = GetStatusDescription(o.Status),
                    MetodoPagamento = GetPaymentMethodDescription(o.PaymentMethod),
                    Total = o.TotalAmount,
                    StatusColor = GetStatusColor(o.Status),
                    OriginalStatus = o.Status // Manter para referência
                }).ToList();
                
                dgvOrders.DataSource = ordersWithDetails;
                ConfigureColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar encomendas: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureColumns()
        {
            if (dgvOrders.Columns.Count > 0)
            {
                dgvOrders.Columns["Id"].HeaderText = "ID";
                dgvOrders.Columns["Id"].Width = 50;
                dgvOrders.Columns["Cliente"].HeaderText = "Cliente ID";
                dgvOrders.Columns["Cliente"].Width = 80;
                dgvOrders.Columns["Data"].HeaderText = "Data";
                dgvOrders.Columns["Data"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                dgvOrders.Columns["Status"].HeaderText = "Estado";
                dgvOrders.Columns["MetodoPagamento"].HeaderText = "Pagamento";
                dgvOrders.Columns["Total"].HeaderText = "Total";
                dgvOrders.Columns["Total"].DefaultCellStyle.Format = "C";
                
                // Ocultar colunas auxiliares
                if (dgvOrders.Columns["StatusColor"] != null)
                    dgvOrders.Columns["StatusColor"].Visible = false;
                
                // Colorir linhas baseado no status
                foreach (DataGridViewRow row in dgvOrders.Rows)
                {
                    if (row.DataBoundItem != null)
                    {
                        var statusColor = row.DataBoundItem.GetType().GetProperty("StatusColor")?.GetValue(row.DataBoundItem);
                        if (statusColor is Color color)
                        {
                            row.DefaultCellStyle.BackColor = color;
                        }
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow?.DataBoundItem != null)
            {
                var selectedItem = dgvOrders.CurrentRow.DataBoundItem;
                var orderId = (int)selectedItem.GetType().GetProperty("Id").GetValue(selectedItem);
                var order = _orderService.GetOrderById(orderId);
                
                if (order != null)
                {
                    var editForm = new OrderEditForm(_orderService, order);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadOrders();
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione uma encomenda para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow?.DataBoundItem != null)
            {
                var selectedItem = dgvOrders.CurrentRow.DataBoundItem;
                var orderId = (int)selectedItem.GetType().GetProperty("Id").GetValue(selectedItem);
                
                if (MessageBox.Show($"Remover encomenda #{orderId}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        _orderService.RemoveOrder(orderId);
                        MessageBox.Show("Encomenda removida com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadOrders();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao remover encomenda: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione uma encomenda para remover.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow?.DataBoundItem != null)
            {
                var selectedItem = dgvOrders.CurrentRow.DataBoundItem;
                var orderId = (int)selectedItem.GetType().GetProperty("Id").GetValue(selectedItem);
                var order = _orderService.GetOrderById(orderId);
                
                if (order != null)
                {
                    var editForm = new OrderEditForm(_orderService, order);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadOrders();
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione uma encomenda para alterar o status.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
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
        
        private Color GetStatusColor(OrderStatus status)
        {
            return status switch
            {
                OrderStatus.Created => Color.LightYellow,
                OrderStatus.Paid => Color.LightBlue,
                OrderStatus.Processing => Color.LightCyan,
                OrderStatus.Shipped => Color.LightGreen,
                OrderStatus.Completed => Color.PaleGreen,
                OrderStatus.Cancelled => Color.LightCoral,
                _ => Color.White
            };
        }
        
        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow?.DataBoundItem != null)
            {
                var selectedItem = dgvOrders.CurrentRow.DataBoundItem;
                var orderId = (int)selectedItem.GetType().GetProperty("Id").GetValue(selectedItem);
                var order = _orderService.GetOrderById(orderId);
                
                if (order != null)
                {
                    if (_clientService != null && _productService != null && _employeeService != null)
                    {
                        using var form = new OrderDetailsForm(order, _clientService, _productService, _employeeService);
                        form.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Serviços não disponíveis para mostrar detalhes.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione uma encomenda para ver detalhes.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        private void DgvOrders_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    btnEdit_Click(sender, EventArgs.Empty);
                    break;
                case Keys.Delete:
                    btnRemove_Click(sender, EventArgs.Empty);
                    break;
                case Keys.F5:
                    LoadOrders();
                    break;
                case Keys.F3:
                    btnDetails_Click(sender, EventArgs.Empty);
                    break;
            }
        }
    }
}
