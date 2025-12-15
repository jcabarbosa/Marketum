namespace Marketum.UI
{
    partial class ClientEditForm : Form
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

            this.txtName = new System.Windows.Forms.TextBox();
            this.txtTaxNr = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();

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

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(120, 230);
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.Text = "Guardar";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(260, 230);
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // ClientEditForm
            this.ClientSize = new System.Drawing.Size(400, 290);
            this.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblName, txtName,
                lblTaxNr, txtTaxNr,
                lblEmail, txtEmail,
                lblPhone, txtPhone,
                lblAddress, txtAddress,
                btnSave, btnCancel
            });
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cliente";

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblTaxNr;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblAddress;

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtTaxNr;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtAddress;

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
