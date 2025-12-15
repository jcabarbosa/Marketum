namespace Marketum.UI
{
    partial class LoginForm : Form
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(110, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(146, 25);
            this.lblTitle.Text = "Marketum Login";

            // lblUsername
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(40, 80);
            this.lblUsername.Text = "Utilizador:";

            // txtUsername
            this.txtUsername.Location = new System.Drawing.Point(140, 77);
            this.txtUsername.Size = new System.Drawing.Size(180, 23);

            // lblPassword
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(40, 120);
            this.lblPassword.Text = "Palavra-passe:";

            // txtPassword
            this.txtPassword.Location = new System.Drawing.Point(140, 117);
            this.txtPassword.Size = new System.Drawing.Size(180, 23);
            this.txtPassword.UseSystemPasswordChar = true;

            // btnLogin
            this.btnLogin.Location = new System.Drawing.Point(140, 170);
            this.btnLogin.Size = new System.Drawing.Size(80, 30);
            this.btnLogin.Text = "Entrar";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // btnExit
            this.btnExit.Location = new System.Drawing.Point(240, 170);
            this.btnExit.Size = new System.Drawing.Size(80, 30);
            this.btnExit.Text = "Sair";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);

            // LoginForm
            this.AcceptButton = this.btnLogin;
            this.ClientSize = new System.Drawing.Size(380, 240);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnExit;
    }
}
