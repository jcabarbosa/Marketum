using System;
using System.Windows.Forms;
using Marketum.Domain;
using Marketum.Services;

namespace Marketum.UI
{
    public partial class EmployeeEditForm : Form
    {
        private readonly IEmployeeService _employeeService;
        private readonly Employee _employee;
        private readonly bool _isEdit;

        public EmployeeEditForm(IEmployeeService employeeService, Employee? employee = null)
        {
            InitializeComponent();

            _employeeService = employeeService;
            _isEdit = employee != null;
            _employee = employee ?? new Employee();

            if (_isEdit)
                LoadData();
        }

        private void LoadData()
        {
            txtName.Text = _employee.Name;
            txtTaxNr.Text = _employee.TaxNr;
            txtEmail.Text = _employee.Email;
            txtPhone.Text = _employee.Phone;
            txtAddress.Text = _employee.Address;

            cmbRoleTitle.SelectedItem = _employee.RoleTitle;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            string roleTitle = cmbRoleTitle.SelectedItem!.ToString()!;

            if (_isEdit)
            {
                _employee.Name = txtName.Text.Trim();
                _employee.TaxNr = txtTaxNr.Text.Trim();
                _employee.Email = txtEmail.Text.Trim();
                _employee.Phone = txtPhone.Text.Trim();
                _employee.Address = txtAddress.Text.Trim();
                _employee.RoleTitle = roleTitle;

                _employeeService.UpdateEmployee(_employee);
            }
            else
            {
                _employeeService.AddEmployee(
                    txtName.Text.Trim(),
                    txtTaxNr.Text.Trim(),
                    txtEmail.Text.Trim(),
                    txtPhone.Text.Trim(),
                    txtAddress.Text.Trim(),
                    roleTitle
                );
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("O nome é obrigatório.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTaxNr.Text))
            {
                MessageBox.Show("O NIF é obrigatório.");
                return false;
            }

            if (cmbRoleTitle.SelectedItem == null)
            {
                MessageBox.Show("O cargo é obrigatório.");
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
