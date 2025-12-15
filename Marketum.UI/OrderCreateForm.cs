using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Marketum.Domain;
using Marketum.Services;

namespace Marketum.UI
{
    public partial class OrderCreateForm : Form
    {
        private readonly IOrderService _orderService;
        private readonly IClientService _clientService;
        private readonly IProductService _productService;
        private readonly Account _loggedAccount;

        private readonly List<(int productId, int quantity)> _items = new();
        private decimal _currentTotal = 0;

        public OrderCreateForm(
            IOrderService orderService,
            IClientService clientService,
            IProductService productService,
            Account loggedAccount)
        {
            InitializeComponent();

            _orderService = orderService;
            _clientService = clientService;
            _productService = productService;
            _loggedAccount = loggedAccount;

            LoadClients();
            LoadProducts();
            LoadPaymentMethods();
            
            // Configurar eventos
            txtQuantity.KeyPress += TxtQuantity_KeyPress;
            dgvItems.KeyDown += DgvItems_KeyDown;
            
            // Configurar tooltips
            var toolTip = new ToolTip();
            toolTip.SetToolTip(btnAddItem, "Adicionar produto à encomenda");
            toolTip.SetToolTip(btnSave, "Criar encomenda");
            toolTip.SetToolTip(dgvItems, "Pressione Delete para remover item selecionado");
        }

        private void LoadClients()
        {
            cmbClient.DataSource = _clientService.GetAllClients();
            cmbClient.DisplayMember = "Name";
            cmbClient.ValueMember = "Id";
        }

        private void LoadProducts()
        {
            cmbProduct.DataSource = _productService.GetAllProducts();
            cmbProduct.DisplayMember = "Name";
            cmbProduct.ValueMember = "Id";
        }

        private void LoadPaymentMethods()
        {
            cmbPaymentMethod.DataSource = Enum.GetValues(typeof(PaymentMethod));
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (cmbProduct.SelectedItem == null)
            {
                MessageBox.Show("Selecione um produto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtQuantity.Text, out int qty) || qty <= 0)
            {
                MessageBox.Show("Insira uma quantidade válida (número positivo).", "Quantidade Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuantity.Focus();
                return;
            }

            var product = (Product)cmbProduct.SelectedItem;
            
            // Validar stock disponível
            if (product.Stock < qty)
            {
                MessageBox.Show($"Stock insuficiente. Disponível: {product.Stock} unidades.", "Stock Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuantity.Focus();
                return;
            }

            // Verificar se produto já existe na lista
            var existingItem = _items.FirstOrDefault(i => i.productId == product.Id);
            if (existingItem != default)
            {
                var totalQty = existingItem.quantity + qty;
                if (product.Stock < totalQty)
                {
                    MessageBox.Show($"Stock insuficiente. Já tem {existingItem.quantity} unidades. Disponível: {product.Stock} unidades.", "Stock Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                // Atualizar quantidade existente
                _items.Remove(existingItem);
                _items.Add((product.Id, totalQty));
            }
            else
            {
                _items.Add((product.Id, qty));
            }

            RefreshItemsList();
            txtQuantity.Clear();
            txtQuantity.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbClient.SelectedItem == null)
            {
                MessageBox.Show("Selecione um cliente.", "Cliente Obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbClient.Focus();
                return;
            }

            if (_items.Count == 0)
            {
                MessageBox.Show("Adicione pelo menos um item à encomenda.", "Items Obrigatórios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbProduct.Focus();
                return;
            }

            if (cmbPaymentMethod.SelectedItem == null)
            {
                MessageBox.Show("Selecione um método de pagamento.", "Método de Pagamento Obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbPaymentMethod.Focus();
                return;
            }

            try
            {
                int clientId = (int)cmbClient.SelectedValue;
                var paymentMethod = (PaymentMethod)cmbPaymentMethod.SelectedItem;

                _orderService.CreateOrder(
                    clientId,
                    _loggedAccount.EmployeeId,
                    _loggedAccount.Role,
                    paymentMethod,
                    _items
                );

                MessageBox.Show("Encomenda criada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao criar encomenda: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RefreshItemsList()
        {
            dgvItems.DataSource = null;
            
            var itemsWithDetails = _items.Select(item => {
                var product = _productService.GetById(item.productId);
                return new {
                    ProductId = item.productId,
                    Produto = product?.Name ?? "Produto não encontrado",
                    Quantidade = item.quantity,
                    PrecoUnitario = product?.Price ?? 0,
                    Total = (product?.Price ?? 0) * item.quantity
                };
            }).ToList();
            
            dgvItems.DataSource = itemsWithDetails;
            
            // Calcular total geral
            _currentTotal = itemsWithDetails.Sum(i => i.Total);
        }

        private void TxtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir apenas números e backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
            
            // Enter para adicionar item
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnAddItem_Click(sender, EventArgs.Empty);
                e.Handled = true;
            }
        }

        private void DgvItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && dgvItems.CurrentRow != null)
            {
                var selectedItem = dgvItems.CurrentRow.DataBoundItem;
                if (selectedItem != null)
                {
                    var productId = (int)selectedItem.GetType().GetProperty("ProductId").GetValue(selectedItem);
                    var itemToRemove = _items.FirstOrDefault(i => i.productId == productId);
                    if (itemToRemove != default)
                    {
                        _items.Remove(itemToRemove);
                        RefreshItemsList();
                    }
                }
            }
        }
    }
}
