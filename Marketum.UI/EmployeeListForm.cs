using System;
using System.Windows.Forms;
using Marketum.Domain;
using Marketum.Services;

namespace Marketum.UI
{
    public partial class EmployeeListForm : Form
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeListForm(IEmployeeService employeeService)
        {
            InitializeComponent();
            _employeeService = employeeService;
        }

        private void EmployeeListForm_Load(object sender, EventArgs e)
        {
            LoadEmployees();
            
            // Configurar double-click para editar
            dgvEmployees.DoubleClick += (s, e) => btnEdit_Click(s, e);
            
            // Configurar atalhos de teclado
            dgvEmployees.KeyDown += DgvEmployees_KeyDown;
        }

        private void LoadEmployees()
        {
            try
            {
                dgvEmployees.DataSource = null;
                var employees = _employeeService.GetAllEmployees();
                dgvEmployees.DataSource = employees;
                
                // Configurar colunas
                if (dgvEmployees.Columns.Count > 0)
                {
                    dgvEmployees.Columns["Id"].HeaderText = "ID";
                    dgvEmployees.Columns["Id"].Width = 50;
                    dgvEmployees.Columns["Name"].HeaderText = "Nome";
                    dgvEmployees.Columns["Email"].HeaderText = "Email";
                    dgvEmployees.Columns["Phone"].HeaderText = "Telefone";
                    dgvEmployees.Columns["RoleTitle"].HeaderText = "Cargo";
                    dgvEmployees.Columns["TaxNr"].HeaderText = "NIF";
                    dgvEmployees.Columns["Address"].HeaderText = "Morada";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar funcionários: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new EmployeeEditForm(_employeeService))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadEmployees();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.CurrentRow?.DataBoundItem is Employee emp)
            {
                using (var form = new EmployeeEditForm(_employeeService, emp))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadEmployees();
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione um funcionário para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.CurrentRow?.DataBoundItem is Employee emp)
            {
                var result = MessageBox.Show(
                    $"Tem a certeza que deseja remover o funcionário '{emp.Name}'?\n\nEsta ação não pode ser desfeita.",
                    "Confirmar Remoção",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        _employeeService.RemoveEmployee(emp.Id);
                        MessageBox.Show("Funcionário removido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadEmployees();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao remover funcionário: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione um funcionário para remover.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        private void DgvEmployees_KeyDown(object sender, KeyEventArgs e)
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
