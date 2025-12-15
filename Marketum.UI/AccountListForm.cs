using System;
using System.Linq;
using System.Windows.Forms;
using Marketum.Domain;
using Marketum.Services;

namespace Marketum.UI
{
    public partial class AccountListForm : Form
    {
        private readonly IAuthService _authService;
        private readonly IEmployeeService _employeeService;

        public AccountListForm(IAuthService authService, IEmployeeService employeeService)
        {
            InitializeComponent();
            _authService = authService;
            _employeeService = employeeService;
        }

        private void AccountListForm_Load(object sender, EventArgs e)
        {
            LoadAccounts();
            
            // Configurar double-click para editar
            dgvAccounts.DoubleClick += (s, e) => btnEdit_Click(s, e);
        }

        private void LoadAccounts()
        {
            try
            {
                dgvAccounts.DataSource = null;
                var accounts = _authService.GetAllAccounts();
                
                var accountsWithDetails = accounts.Select(a => {
                    var employee = _employeeService.GetById(a.EmployeeId);
                    return new {
                        a.Id,
                        a.Username,
                        Funcionario = employee?.Name ?? "N/A",
                        Role = GetRoleDescription(a.Role),
                        a.EmployeeId
                    };
                }).ToList();
                
                dgvAccounts.DataSource = accountsWithDetails;
                
                // Configurar colunas
                if (dgvAccounts.Columns.Count > 0)
                {
                    dgvAccounts.Columns["Id"].HeaderText = "ID";
                    dgvAccounts.Columns["Id"].Width = 50;
                    dgvAccounts.Columns["Username"].HeaderText = "Utilizador";
                    dgvAccounts.Columns["Funcionario"].HeaderText = "Funcionário";
                    dgvAccounts.Columns["Role"].HeaderText = "Perfil";
                    dgvAccounts.Columns["EmployeeId"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar contas: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new AccountEditForm(_authService, _employeeService))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadAccounts();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Edição de contas não é permitida por segurança.\n\nPara alterar dados, remova a conta e crie uma nova.", "Funcionalidade Restrita", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvAccounts.CurrentRow?.DataBoundItem != null)
            {
                var selectedItem = dgvAccounts.CurrentRow.DataBoundItem;
                var username = selectedItem.GetType().GetProperty("Username").GetValue(selectedItem).ToString();
                
                var result = MessageBox.Show(
                    $"Tem a certeza que deseja remover a conta '{username}'?\n\nEsta ação não pode ser desfeita.", 
                    "Confirmar Remoção", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question);
                    
                if (result == DialogResult.Yes)
                {
                    MessageBox.Show("Remoção de contas não implementada por segurança.", "Funcionalidade Restrita", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Selecione uma conta para remover.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        private string GetRoleDescription(UserRole role)
        {
            return role switch
            {
                UserRole.Admin => "Administrador",
                UserRole.Employee => "Funcionário",
                UserRole.StockManager => "Gestor de Stock",
                _ => role.ToString()
            };
        }
    }
}
