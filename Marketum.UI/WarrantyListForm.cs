using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Marketum.Domain;
using Marketum.Services;

namespace Marketum.UI
{
    public partial class WarrantyListForm : Form
    {
        private readonly IWarrantyService _warrantyService;
        private readonly IProductService _productService;

        public WarrantyListForm(IWarrantyService warrantyService, IProductService productService)
        {
            InitializeComponent();
            _warrantyService = warrantyService;
            _productService = productService;
            
            // Configurar double-click para editar
            dgvWarranties.DoubleClick += (s, e) => btnEdit_Click(s, e);
        }

        private void WarrantyListForm_Load(object sender, EventArgs e)
        {
            LoadWarranties();
        }

        private void LoadWarranties()
        {
            try
            {
                var warranties = _warrantyService.GetAllWarranties();
                var warrantiesWithStatus = warranties.Select(w => new {
                    w.Id,
                    w.Name,
                    Duracao = $"{w.DurationMonths} meses",
                    w.Description,
                    Estado = w.IsActive ? "Ativo" : "Inativo",
                    w.IsActive
                }).ToList();
                
                dgvWarranties.DataSource = null;
                dgvWarranties.DataSource = warrantiesWithStatus;
                
                // Configurar colunas
                if (dgvWarranties.Columns.Count > 0)
                {
                    dgvWarranties.Columns["Id"].HeaderText = "ID";
                    dgvWarranties.Columns["Id"].Width = 50;
                    dgvWarranties.Columns["Name"].HeaderText = "Nome";
                    dgvWarranties.Columns["Duracao"].HeaderText = "Duração";
                    dgvWarranties.Columns["Description"].HeaderText = "Descrição";
                    dgvWarranties.Columns["Estado"].HeaderText = "Estado";
                    dgvWarranties.Columns["IsActive"].Visible = false;
                    
                    // Colorir linhas inativas
                    foreach (DataGridViewRow row in dgvWarranties.Rows)
                    {
                        var isActive = (bool)row.Cells["IsActive"].Value;
                        if (!isActive)
                        {
                            row.DefaultCellStyle.BackColor = Color.LightGray;
                            row.DefaultCellStyle.ForeColor = Color.DarkGray;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar garantias: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using var form = new WarrantyEditForm(_warrantyService);
            if (form.ShowDialog() == DialogResult.OK)
                LoadWarranties();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvWarranties.CurrentRow?.DataBoundItem != null)
            {
                var selectedItem = dgvWarranties.CurrentRow.DataBoundItem;
                var warrantyId = (int)selectedItem.GetType().GetProperty("Id").GetValue(selectedItem);
                var warranty = _warrantyService.GetById(warrantyId);
                
                if (warranty != null)
                {
                    using var form = new WarrantyEditForm(_warrantyService, warranty);
                    if (form.ShowDialog() == DialogResult.OK)
                        LoadWarranties();
                }
            }
            else
            {
                MessageBox.Show("Selecione uma garantia para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvWarranties.CurrentRow?.DataBoundItem != null)
            {
                var selectedItem = dgvWarranties.CurrentRow.DataBoundItem;
                var warrantyId = (int)selectedItem.GetType().GetProperty("Id").GetValue(selectedItem);
                var warrantyName = selectedItem.GetType().GetProperty("Name").GetValue(selectedItem).ToString();
                
                var result = MessageBox.Show(
                    $"Tem a certeza que deseja remover o template '{warrantyName}'?\n\nEsta ação não pode ser desfeita.", 
                    "Confirmar Remoção", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question);
                    
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        _warrantyService.RemoveWarranty(warrantyId);
                        MessageBox.Show("Template removido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadWarranties();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao remover template: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione uma garantia para remover.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
