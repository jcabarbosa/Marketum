namespace Marketum.UI
{
    partial class EmployeeEditForm : Form
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
            this.lblName = new System.Windows.Forms.Label();
            this.lblTaxNr = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblRoleTitle = new System.Windows.Forms.Label();

            this.txtName = new System.Windows.Forms.TextBox();
            this.txtTaxNr = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();

            this.cmbRoleTitle = new System.Windows.Forms.ComboBox();

            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // lblName
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(20, 20);
            this.lblName.Text = "Nome:";

            // txtName
            this.txtName.Location = new System.Drawing.Point(120, 17);
            this.txtName.Size = new System.Drawing.Size(240, 23);

            // lblTaxNr
            this.lblTaxNr.AutoSize = true;
            this.lblTaxNr.Location = new System.Drawing.Point(20, 60);
            this.lblTaxNr.Text = "NIF:";

            // txtTaxNr
            this.txtTaxNr.Location = new System.Drawing.Point(120, 57);
            this.txtTaxNr.Size = new System.Drawing.Size(240, 23);

            // lblEmail
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(20, 100);
            this.lblEmail.Text = "Email:";

            // txtEmail
            this.txtEmail.Location = new System.Drawing.Point(120, 97);
            this.txtEmail.Size = new System.Drawing.Size(240, 23);

            // lblPhone
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(20, 140);
            this.lblPhone.Text = "Telefone:";

            // txtPhone
            this.txtPhone.Location = new System.Drawing.Point(120, 137);
            this.txtPhone.Size = new System.Drawing.Size(240, 23);

            // lblAddress
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(20, 180);
            this.lblAddress.Text = "Morada:";

            // txtAddress
            this.txtAddress.Location = new System.Drawing.Point(120, 177);
            this.txtAddress.Size = new System.Drawing.Size(240, 23);

            // lblRoleTitle
            this.lblRoleTitle.AutoSize = true;
            this.lblRoleTitle.Location = new System.Drawing.Point(20, 220);
            this.lblRoleTitle.Text = "Cargo:";

            // cmbRoleTitle
            this.cmbRoleTitle.Location = new System.Drawing.Point(120, 217);
            this.cmbRoleTitle.Size = new System.Drawing.Size(240, 23);
            this.cmbRoleTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoleTitle.Items.AddRange(new object[]
            {
                "Admin",
                "Funcionário",
                "Gestor de Stock"
            });

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(120, 270);
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.Text = "Guardar";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(260, 270);
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // EmployeeEditForm
            this.ClientSize = new System.Drawing.Size(400, 330);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblTaxNr);
            this.Controls.Add(this.txtTaxNr);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblRoleTitle);
            this.Controls.Add(this.cmbRoleTitle);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Funcionário";

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblTaxNr;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblRoleTitle;

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtTaxNr;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtAddress;

        private System.Windows.Forms.ComboBox cmbRoleTitle;

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
