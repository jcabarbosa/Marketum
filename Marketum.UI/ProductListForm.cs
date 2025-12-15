using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Marketum.Domain;
using Marketum.Services;

namespace Marketum.UI
{
    public partial class ProductListForm : Form
    {
        private readonly IProductService _productService;
        private readonly IBrandService _brandService;
        private readonly ICategoryService _categoryService;

        private readonly IWarrantyService _warrantyService;
        
        public ProductListForm(IProductService productService, IBrandService brandService, ICategoryService categoryService, IWarrantyService warrantyService = null)
        {
            InitializeComponent();
            _productService = productService;
            _brandService = brandService;
            _categoryService = categoryService;
            _warrantyService = warrantyService;
        }

        private void ProductListForm_Load(object sender, EventArgs e)
        {
            LoadProducts();
            
            // Configurar double-click para editar
            dgvProducts.DoubleClick += (s, e) => btnEdit_Click(s, e);
            
            // Configurar atalhos de teclado
            dgvProducts.KeyDown += DgvProducts_KeyDown;
        }

        private void LoadProducts()
        {
            try
            {
                var products = _productService.GetAllProducts();
                var productsWithDetails = products.Select(p => new {
                    p.Id,
                    p.Name,
                    Preco = p.Price,
                    Stock = p.Stock,
                    StockStatus = p.Stock <= 5 ? "BAIXO" : "OK",
                    Marca = _brandService.GetBrandById(p.BrandId)?.Name ?? "N/A",
                    Categoria = _categoryService.GetCategoryById(p.CategoryId)?.Name ?? "N/A"
                }).ToList();
                
                dgvProducts.DataSource = null;
                dgvProducts.DataSource = productsWithDetails;
                
                // Configurar colunas
                if (dgvProducts.Columns.Count > 0)
                {
                    dgvProducts.Columns["Id"].HeaderText = "ID";
                    dgvProducts.Columns["Id"].Width = 50;
                    dgvProducts.Columns["Name"].HeaderText = "Nome";
                    dgvProducts.Columns["Preco"].HeaderText = "Preço";
                    dgvProducts.Columns["Preco"].DefaultCellStyle.Format = "C";
                    dgvProducts.Columns["Stock"].HeaderText = "Stock";
                    dgvProducts.Columns["StockStatus"].HeaderText = "Estado Stock";
                    dgvProducts.Columns["Marca"].HeaderText = "Marca";
                    dgvProducts.Columns["Categoria"].HeaderText = "Categoria";
                    
                    // Colorir linhas com stock baixo
                    foreach (DataGridViewRow row in dgvProducts.Rows)
                    {
                        if (row.Cells["StockStatus"].Value?.ToString() == "BAIXO")
                        {
                            row.DefaultCellStyle.BackColor = Color.LightCoral;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar produtos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new ProductEditForm(_productService, _brandService, _categoryService, _warrantyService))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadProducts();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null)
            {
                MessageBox.Show("Selecione um produto para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedItem = dgvProducts.CurrentRow.DataBoundItem;
            var productId = (int)selectedItem.GetType().GetProperty("Id").GetValue(selectedItem);
            var product = _productService.GetById(productId);

            using (var form = new ProductEditForm(_productService, _brandService, _categoryService, _warrantyService, product))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadProducts();
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null)
            {
                MessageBox.Show("Selecione um produto para remover.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedItem = dgvProducts.CurrentRow.DataBoundItem;
            var productId = (int)selectedItem.GetType().GetProperty("Id").GetValue(selectedItem);
            var productName = selectedItem.GetType().GetProperty("Name").GetValue(selectedItem).ToString();

            var confirm = MessageBox.Show(
                $"Tem a certeza que deseja remover o produto '{productName}'?\n\nEsta ação não pode ser desfeita.",
                "Confirmar Remoção",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _productService.RemoveProduct(productId);
                    MessageBox.Show("Produto removido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProducts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao remover produto: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        private void DgvProducts_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    btnEdit_Click(sender, EventArgs.Empty);
                    break;
                case Keys.Delete:
                    btnRemove_Click(sender, EventArgs.Empty);
                    break;
                case Keys.Insert:
                    btnAdd_Click(sender, EventArgs.Empty);
                    break;
            }
        }
    }
}
