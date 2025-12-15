using System;
using System.Windows.Forms;
using Marketum.Services;

namespace Marketum.UI
{
    public partial class CampaignCreateForm : Form
    {
        private readonly ICampaignService _campaignService;

        public CampaignCreateForm(ICampaignService campaignService)
        {
            InitializeComponent();
            _campaignService = campaignService;
            
            // Configurar datas padrão
            dtpStartDate.Value = DateTime.Now.Date;
            dtpEndDate.Value = DateTime.Now.Date.AddDays(30);
            
            // Configurar eventos
            dtpStartDate.ValueChanged += DtpStartDate_ValueChanged;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            try
            {
                string name = txtName.Text.Trim();
                DateTime startDate = dtpStartDate.Value;
                DateTime endDate = dtpEndDate.Value;
                decimal discount = numDiscount.Value;

                _campaignService.AddCampaign(name, startDate, endDate, discount);
                
                MessageBox.Show("Campanha criada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao criar campanha: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Nome da campanha é obrigatório.", "Campo Obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            if (txtName.Text.Trim().Length < 3)
            {
                MessageBox.Show("Nome da campanha deve ter pelo menos 3 caracteres.", "Nome Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            if (dtpStartDate.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Data de início não pode ser anterior a hoje.", "Data Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpStartDate.Focus();
                return false;
            }

            if (dtpStartDate.Value >= dtpEndDate.Value)
            {
                MessageBox.Show("Data de fim deve ser posterior à data de início.", "Datas Inválidas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpEndDate.Focus();
                return false;
            }

            var duration = dtpEndDate.Value - dtpStartDate.Value;
            if (duration.TotalDays > 365)
            {
                MessageBox.Show("Campanha não pode durar mais de 1 ano.", "Duração Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpEndDate.Focus();
                return false;
            }

            if (numDiscount.Value <= 0 || numDiscount.Value > 100)
            {
                MessageBox.Show("Desconto deve estar entre 1% e 100%.", "Desconto Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numDiscount.Focus();
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private void DtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            // Ajustar data de fim automaticamente se for anterior à data de início
            if (dtpEndDate.Value <= dtpStartDate.Value)
            {
                dtpEndDate.Value = dtpStartDate.Value.AddDays(1);
            }
        }
    }
}