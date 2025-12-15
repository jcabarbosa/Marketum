using System;
using System.Windows.Forms;
using Marketum.Domain;
using Marketum.Services;

namespace Marketum.UI
{
    public partial class WarrantyEditForm : Form
    {
        private readonly IWarrantyService _warrantyService;
        private readonly Warranty _warranty;
        private readonly bool _isEdit;

        public WarrantyEditForm(IWarrantyService warrantyService, Warranty warranty = null)
        {
            InitializeComponent();
            _warrantyService = warrantyService;
            _warranty = warranty;
            _isEdit = warranty != null;
            
            if (_isEdit)
            {
                LoadWarrantyData();
                Text = "Editar Template de Garantia";
            }
            else
            {
                Text = "Novo Template de Garantia";
                chkActive.Checked = true;
            }
        }
        
        private void LoadWarrantyData()
        {
            txtName.Text = _warranty.Name;
            numDuration.Value = _warranty.DurationMonths;
            txtDescription.Text = _warranty.Description;
            chkActive.Checked = _warranty.IsActive;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            try
            {
                string name = txtName.Text.Trim();
                int duration = (int)numDuration.Value;
                string description = txtDescription.Text.Trim();
                bool isActive = chkActive.Checked;

                if (_isEdit)
                {
                    _warranty.Name = name;
                    _warranty.DurationMonths = duration;
                    _warranty.Description = description;
                    _warranty.IsActive = isActive;
                    
                    _warrantyService.UpdateWarranty(_warranty);
                    MessageBox.Show("Template de garantia atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _warrantyService.CreateWarranty(name, duration, description);
                    MessageBox.Show("Template de garantia criado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao guardar garantia: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Nome da garantia é obrigatório.", "Campo Obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            if (numDuration.Value <= 0)
            {
                MessageBox.Show("Duração deve ser maior que zero.", "Duração Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numDuration.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Descrição é obrigatória.", "Campo Obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescription.Focus();
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
