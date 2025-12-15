using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Marketum.Domain;
using Marketum.Services;

namespace Marketum.UI
{
    public partial class StockForm : Form
    {
        private readonly IProductService _productService;

        public StockForm(IProductService productService)
        {
            InitializeComponent();
            _productService = productService;
        }

        private void StockForm_Load(object sender, EventArgs e)
        {
            LoadProducts();
            
            // Configurar eventos
            txtQuantity.KeyPress += TxtQuantity_KeyPress;
            dgvProducts.SelectionChanged += DgvProducts_SelectionChanged;
        }

        private void LoadProducts()
        {
            try
            {
                var products = _productService.GetAllProducts();
                var productsWithStatus = products.Select(p => new {
                    p.Id,
                    p.Name,
                    StockAtual = p.Stock,
                    Status = p.Stock <= 5 ? "BAIXO" : p.Stock <= 10 ? "MÉDIO" : "OK",
                    p.Price
                }).ToList();
                
                dgvProducts.DataSource = null;
                dgvProducts.DataSource = productsWithStatus;
                
                // Configurar colunas
                if (dgvProducts.Columns.Count > 0)
                {
                    dgvProducts.Columns["Id"].HeaderText = "ID";
                    dgvProducts.Columns["Id"].Width = 50;
                    dgvProducts.Columns["Name"].HeaderText = "Produto";
                    dgvProducts.Columns["StockAtual"].HeaderText = "Stock Atual";
                    dgvProducts.Columns["Status"].HeaderText = "Estado";
                    dgvProducts.Columns["Price"].HeaderText = "Preço";
                    dgvProducts.Columns["Price"].DefaultCellStyle.Format = "C";
                    
                    // Colorir linhas baseado no stock
                    foreach (DataGridViewRow row in dgvProducts.Rows)
                    {
                        var status = row.Cells["Status"].Value?.ToString();
                        switch (status)
                        {
                            case "BAIXO":
                                row.DefaultCellStyle.BackColor = Color.LightCoral;
                                break;
                            case "MÉDIO":
                                row.DefaultCellStyle.BackColor = Color.LightYellow;
                                break;
                            case "OK":
                                row.DefaultCellStyle.BackColor = Color.LightGreen;
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar produtos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateStock_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null)
            {
                MessageBox.Show("Selecione um produto para atualizar o stock.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtQuantity.Text, out int quantity))
            {
                MessageBox.Show("Insira uma quantidade válida (número inteiro).", "Quantidade Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuantity.Focus();
                return;
            }

            var selectedItem = dgvProducts.CurrentRow.DataBoundItem;
            var productId = (int)selectedItem.GetType().GetProperty("Id").GetValue(selectedItem);
            var productName = selectedItem.GetType().GetProperty("Name").GetValue(selectedItem).ToString();
            var currentStock = (int)selectedItem.GetType().GetProperty("StockAtual").GetValue(selectedItem);
            
            var newStock = currentStock + quantity;
            if (newStock < 0)
            {
                MessageBox.Show($"Operação resultaria em stock negativo.\nStock atual: {currentStock}\nQuantidade: {quantity}\nResultado: {newStock}", "Stock Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _productService.UpdateStock(productId, quantity);
                
                var operation = quantity >= 0 ? "adicionadas" : "removidas";
                MessageBox.Show($"Stock atualizado com sucesso!\n\nProduto: {productName}\nQuantidade {operation}: {Math.Abs(quantity)}\nNovo stock: {newStock}", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                LoadProducts();
                txtQuantity.Clear();
                txtQuantity.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar stock: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void TxtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números, sinal negativo e backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '-')
            {
                e.Handled = true;
            }
            
            // Permitir apenas um sinal negativo no início
            if (e.KeyChar == '-' && (txtQuantity.SelectionStart != 0 || txtQuantity.Text.Contains("-")))
            {
                e.Handled = true;
            }
            
            // Enter para atualizar stock
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnUpdateStock_Click(sender, EventArgs.Empty);
                e.Handled = true;
            }
        }
        
        private void DgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            // Limpar campo de quantidade quando seleção muda
            txtQuantity.Clear();
        }
    }
}
