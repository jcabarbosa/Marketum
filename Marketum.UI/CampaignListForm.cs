using System;
using System.Windows.Forms;
using Marketum.Services;

namespace Marketum.UI
{
    public partial class CampaignListForm : Form
    {
        private readonly ICampaignService _campaignService;

        public CampaignListForm(ICampaignService campaignService)
        {
            InitializeComponent();
            _campaignService = campaignService;
        }

        private void CampaignListForm_Load(object sender, EventArgs e)
        {
            LoadCampaigns();
        }

        private void LoadCampaigns()
        {
            dgvCampaigns.DataSource = null;
            dgvCampaigns.DataSource = _campaignService.GetAllCampaigns();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using var form = new CampaignCreateForm(_campaignService);
            if (form.ShowDialog() == DialogResult.OK)
                LoadCampaigns();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvCampaigns.CurrentRow?.DataBoundItem != null)
            {
                var selectedItem = dgvCampaigns.CurrentRow.DataBoundItem;
                var campaignId = (int)selectedItem.GetType().GetProperty("Id").GetValue(selectedItem);
                var campaignName = selectedItem.GetType().GetProperty("Name").GetValue(selectedItem).ToString();
                
                var result = MessageBox.Show(
                    $"Tem a certeza que deseja remover a campanha '{campaignName}'?\n\nEsta ação não pode ser desfeita.", 
                    "Confirmar Remoção", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question);
                    
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        _campaignService.RemoveCampaign(campaignId);
                        MessageBox.Show("Campanha removida com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCampaigns();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao remover campanha: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione uma campanha para remover.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}