using System;
using System.Windows.Forms;
using Marketum.Domain;
using Marketum.Services;

namespace Marketum.UI
{
    public partial class AccountEditForm : Form
    {
        private readonly IAuthService _authService;
        private readonly IEmployeeService _employeeService;

        public AccountEditForm(IAuthService authService, IEmployeeService employeeService)
        {
            InitializeComponent();

            _authService = authService;
            _employeeService = employeeService;

            LoadRoles();
            LoadEmployees();
        }

        private void LoadRoles()
        {
            cmbRole.DataSource = Enum.GetValues(typeof(UserRole));
        }

        private void LoadEmployees()
        {
            var employees = _employeeService.GetAllEmployees();
            cmbEmployee.DataSource = employees;
            cmbEmployee.DisplayMember = "Name";
            cmbEmployee.ValueMember = "Id";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            var role = (UserRole)cmbRole.SelectedItem;
            int employeeId = (int)cmbEmployee.SelectedValue;

            bool success = _authService.Register(employeeId, username, password, role);
            
            if (success)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Erro ao criar conta. Username já existe.");
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Username obrigatório.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Password obrigatória.");
                return false;
            }

            if (cmbEmployee.SelectedItem == null)
            {
                MessageBox.Show("Funcionário obrigatório.");
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
