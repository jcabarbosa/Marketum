using System;
using System.Windows.Forms;
using Marketum.Domain;
using Marketum.Services;

namespace Marketum.UI
{
    public partial class CategoryListForm : Form
    {
        private readonly ICategoryService _categoryService;

        public CategoryListForm(ICategoryService categoryService)
        {
            InitializeComponent();
            _categoryService = categoryService;
        }

        private void CategoryListForm_Load(object sender, EventArgs e)
        {
            LoadCategories();
            
            // Configurar double-click para editar
            dgvCategories.DoubleClick += (s, e) => btnEdit_Click(s, e);
            
            // Configurar atalhos de teclado
            dgvCategories.KeyDown += DgvCategories_KeyDown;
        }

        private void LoadCategories()
        {
            try
            {
                dgvCategories.DataSource = null;
                var categories = _categoryService.GetAllCategories();
                dgvCategories.DataSource = categories;
                
                // Configurar colunas
                if (dgvCategories.Columns.Count > 0)
                {
                    dgvCategories.Columns["Id"].HeaderText = "ID";
                    dgvCategories.Columns["Id"].Width = 50;
                    dgvCategories.Columns["Name"].HeaderText = "Nome";
                    dgvCategories.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar categorias: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using var form = new CategoryEditForm(_categoryService);
            if (form.ShowDialog() == DialogResult.OK)
                LoadCategories();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCategories.CurrentRow?.DataBoundItem is Category category)
            {
                using var form = new CategoryEditForm(_categoryService, category);
                if (form.ShowDialog() == DialogResult.OK)
                    LoadCategories();
            }
            else
            {
                MessageBox.Show("Selecione uma categoria para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvCategories.CurrentRow?.DataBoundItem is Category category)
            {
                var result = MessageBox.Show(
                    $"Tem a certeza que deseja remover a categoria '{category.Name}'?\n\nEsta ação não pode ser desfeita.", 
                    "Confirmar Remoção", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question);
                    
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        _categoryService.RemoveCategory(category.Id);
                        MessageBox.Show("Categoria removida com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCategories();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao remover categoria: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione uma categoria para remover.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        private void DgvCategories_KeyDown(object sender, KeyEventArgs e)
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
