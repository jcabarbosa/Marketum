using System;
using System.Windows.Forms;
using Marketum.Domain;
using Marketum.Services;

namespace Marketum.UI
{
    public partial class CategoryEditForm : Form
    {
        private readonly ICategoryService _categoryService;
        private readonly Category _category;
        private readonly bool _isEdit;

        public CategoryEditForm(ICategoryService categoryService, Category category = null)
        {
            InitializeComponent();
            _categoryService = categoryService;
            _category = category;
            _isEdit = category != null;

            if (_isEdit)
                txtName.Text = _category.Name;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Nome é obrigatório.");
                return;
            }

            if (_isEdit)
            {
                _category.Name = txtName.Text.Trim();
                _categoryService.UpdateCategory(_category);
            }
            else
            {
                _categoryService.AddCategory(txtName.Text.Trim());
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
