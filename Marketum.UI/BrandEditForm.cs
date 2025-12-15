using System;
using System.Windows.Forms;
using Marketum.Domain;
using Marketum.Services;

namespace Marketum.UI
{
    public partial class BrandEditForm : Form
    {
        private readonly IBrandService _brandService;
        private readonly Brand _brand;
        private readonly bool _isEdit;

        public BrandEditForm(IBrandService brandService, Brand brand = null)
        {
            InitializeComponent();
            _brandService = brandService;
            _brand = brand;
            _isEdit = brand != null;

            if (_isEdit)
            {
                txtName.Text = _brand.Name;
                Text = "Editar Marca";
            }
            else
            {
                Text = "Nova Marca";
            }
            
            // Configurar eventos
            txtName.KeyPress += TxtName_KeyPress;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Nome da marca é obrigatório.", "Campo Obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            if (txtName.Text.Trim().Length < 2)
            {
                MessageBox.Show("Nome da marca deve ter pelo menos 2 caracteres.", "Nome Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            try
            {
                if (_isEdit)
                {
                    _brand.Name = txtName.Text.Trim();
                    _brandService.UpdateBrand(_brand);
                    MessageBox.Show("Marca atualizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _brandService.AddBrand(txtName.Text.Trim());
                    MessageBox.Show("Marca criada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao guardar marca: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private void TxtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Enter para guardar
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSave_Click(sender, EventArgs.Empty);
                e.Handled = true;
            }
            // Escape para cancelar
            else if (e.KeyChar == (char)Keys.Escape)
            {
                btnCancel_Click(sender, EventArgs.Empty);
                e.Handled = true;
            }
        }
    }
}
