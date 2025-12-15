using System;
using System.Windows.Forms;
using Marketum.Domain;
using Marketum.Services;

namespace Marketum.UI
{
    public partial class LoginForm : Form
    {
        private readonly IAuthService _authService;

        public Account? AuthenticatedAccount { get; private set; }

        public LoginForm(IAuthService authService)
        {
            InitializeComponent();
            _authService = authService;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var account = _authService.Login(
                txtUsername.Text,
                txtPassword.Text
            );

            if (account == null)
            {
                MessageBox.Show("Credenciais inválidas.");
                return;
            }

            AuthenticatedAccount = account;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
