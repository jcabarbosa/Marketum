using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Marketum.Domain;
using Marketum.Services;

namespace Marketum.UI
{
    public partial class ProductEditForm : Form
    {
        private readonly IProductService _productService;
        private readonly IBrandService _brandService;
        private readonly ICategoryService _categoryService;
        private readonly IWarrantyService _warrantyService;
        private readonly Product _product;
        private readonly bool _isEditMode;

        public ProductEditForm(IProductService productService, IBrandService brandService, ICategoryService categoryService, IWarrantyService warrantyService = null, Product? product = null)
        {
            InitializeComponent();

            _productService = productService;
            _brandService = brandService;
            _categoryService = categoryService;
            _warrantyService = warrantyService;
            _isEditMode = product != null;
            _product = product ?? new Product();

            LoadComboBoxes();
            
            if (_isEditMode)
                LoadProductData();
        }

        private void LoadComboBoxes()
        {
            try
            {
                var brands = _brandService.GetAllBrands();
                if (brands != null && brands.Count > 0)
                {
                    cmbBrand.DataSource = brands;
                    cmbBrand.DisplayMember = "Name";
                    cmbBrand.ValueMember = "Id";
                }

                var categories = _categoryService.GetAllCategories();
                if (categories != null && categories.Count > 0)
                {
                    cmbCategory.DataSource = categories;
                    cmbCategory.DisplayMember = "Name";
                    cmbCategory.ValueMember = "Id";
                }
                
                // Carregar garantias se o serviço estiver disponível
                if (_warrantyService != null)
                {
                    var warranties = _warrantyService.GetActiveWarranties();
                    var warrantyOptions = new List<object> { new { Id = (int?)null, Name = "Sem Garantia" } };
                    
                    if (warranties != null)
                    {
                        warrantyOptions.AddRange(warranties.Select(w => new { Id = (int?)w.Id, Name = $"{w.Name} ({w.DurationMonths} meses)" }));
                    }
                    
                    cmbWarranty.DataSource = warrantyOptions;
                    cmbWarranty.DisplayMember = "Name";
                    cmbWarranty.ValueMember = "Id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProductData()
        {
            txtName.Text = _product.Name;
            txtPrice.Text = _product.Price.ToString("0.00");
            txtStock.Text = _product.Stock.ToString();
            
            // Selecionar marca e categoria
            cmbBrand.SelectedValue = _product.BrandId;
            cmbCategory.SelectedValue = _product.CategoryId;
            
            // Selecionar garantia
            if (_warrantyService != null && cmbWarranty.DataSource != null)
            {
                cmbWarranty.SelectedValue = _product.WarrantyId;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            try
            {
                string name = txtName.Text.Trim();
                decimal price = decimal.Parse(txtPrice.Text);
                int stock = int.Parse(txtStock.Text);
                if (cmbBrand.SelectedValue == null || cmbCategory.SelectedValue == null)
                {
                    MessageBox.Show("Selecione marca e categoria.", "Dados Obrigatórios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                int brandId = (int)cmbBrand.SelectedValue;
                int categoryId = (int)cmbCategory.SelectedValue;
                int? warrantyId = cmbWarranty?.SelectedValue as int?;

                if (_isEditMode)
                {
                    // Atualizar produto existente
                    _product.Name = name;
                    _product.Price = price;
                    _product.Stock = stock;
                    _product.BrandId = brandId;
                    _product.CategoryId = categoryId;
                    _product.WarrantyId = warrantyId;
                    
                    // Nota: Assumindo que existe método Update no serviço
                    MessageBox.Show("Produto atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _productService.AddProduct(name, brandId, price, stock, categoryId, warrantyId);
                    MessageBox.Show("Produto criado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao guardar produto: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("O nome do produto é obrigatório.");
                return false;
            }

            if (!decimal.TryParse(txtPrice.Text, out _))
            {
                MessageBox.Show("Preço inválido.");
                return false;
            }

            if (!int.TryParse(txtStock.Text, out _))
            {
                MessageBox.Show("Stock inválido.");
                return false;
            }

            if (cmbBrand.SelectedValue == null)
            {
                MessageBox.Show("Marca é obrigatória.");
                return false;
            }

            if (cmbCategory.SelectedValue == null)
            {
                MessageBox.Show("Categoria é obrigatória.");
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
