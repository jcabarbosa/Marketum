using System;
using System.Windows.Forms;
using Marketum.Domain;
using Marketum.Services;

namespace Marketum.UI
{
    public partial class BrandListForm : Form
    {
        private readonly IBrandService _brandService;

        public BrandListForm(IBrandService brandService)
        {
            InitializeComponent();
            _brandService = brandService;
        }

        private void BrandListForm_Load(object sender, EventArgs e)
        {
            LoadBrands();
            
            // Configurar double-click para editar
            dgvBrands.DoubleClick += (s, e) => btnEdit_Click(s, e);
            
            // Configurar atalhos de teclado
            dgvBrands.KeyDown += DgvBrands_KeyDown;
        }

        private void LoadBrands()
        {
            try
            {
                dgvBrands.DataSource = null;
                var brands = _brandService.GetAllBrands();
                dgvBrands.DataSource = brands;
                
                // Configurar colunas
                if (dgvBrands.Columns.Count > 0)
                {
                    dgvBrands.Columns["Id"].HeaderText = "ID";
                    dgvBrands.Columns["Id"].Width = 50;
                    dgvBrands.Columns["Name"].HeaderText = "Nome";
                    dgvBrands.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar marcas: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using var form = new BrandEditForm(_brandService);
            if (form.ShowDialog() == DialogResult.OK)
                LoadBrands();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvBrands.CurrentRow?.DataBoundItem is Brand brand)
            {
                using var form = new BrandEditForm(_brandService, brand);
                if (form.ShowDialog() == DialogResult.OK)
                    LoadBrands();
            }
            else
            {
                MessageBox.Show("Selecione uma marca para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvBrands.CurrentRow?.DataBoundItem is Brand brand)
            {
                var result = MessageBox.Show(
                    $"Tem a certeza que deseja remover a marca '{brand.Name}'?\n\nEsta ação não pode ser desfeita.", 
                    "Confirmar Remoção", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question);
                    
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        _brandService.RemoveBrand(brand.Id);
                        MessageBox.Show("Marca removida com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadBrands();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao remover marca: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione uma marca para remover.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        private void DgvBrands_KeyDown(object sender, KeyEventArgs e)
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
