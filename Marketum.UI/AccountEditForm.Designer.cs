namespace Marketum.UI
{
    partial class AccountEditForm : Form
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();

            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.cmbEmployee = new System.Windows.Forms.ComboBox();
            this.cmbRole = new System.Windows.Forms.ComboBox();

            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // lblUsername
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(20, 20);
            this.lblUsername.Text = "Username:";

            // txtUsername
            this.txtUsername.Location = new System.Drawing.Point(120, 17);
            this.txtUsername.Size = new System.Drawing.Size(220, 23);

            // lblPassword
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(20, 60);
            this.lblPassword.Text = "Password:";

            // txtPassword
            this.txtPassword.Location = new System.Drawing.Point(120, 57);
            this.txtPassword.Size = new System.Drawing.Size(220, 23);
            this.txtPassword.UseSystemPasswordChar = true;

            // lblEmployee
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Location = new System.Drawing.Point(20, 100);
            this.lblEmployee.Text = "Funcionário:";

            // cmbEmployee
            this.cmbEmployee.Location = new System.Drawing.Point(120, 97);
            this.cmbEmployee.Size = new System.Drawing.Size(220, 23);
            this.cmbEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // lblRole
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(20, 140);
            this.lblRole.Text = "Perfil:";

            // cmbRole
            this.cmbRole.Location = new System.Drawing.Point(120, 137);
            this.cmbRole.Size = new System.Drawing.Size(220, 23);
            this.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(120, 190);
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.Text = "Guardar";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(240, 190);
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // AccountEditForm
            this.ClientSize = new System.Drawing.Size(380, 240);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblEmployee);
            this.Controls.Add(this.cmbEmployee);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.cmbRole);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Conta de Acesso";

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.Label lblRole;

        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ComboBox cmbEmployee;
        private System.Windows.Forms.ComboBox cmbRole;

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
