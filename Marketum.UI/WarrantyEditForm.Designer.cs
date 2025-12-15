namespace Marketum.UI
{
    partial class WarrantyEditForm : Form
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();

            this.txtName = new System.Windows.Forms.TextBox();
            this.numDuration = new System.Windows.Forms.NumericUpDown();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.chkActive = new System.Windows.Forms.CheckBox();

            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // lblName
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(20, 20);
            this.lblName.Text = "Nome:";

            // txtName
            this.txtName.Location = new System.Drawing.Point(120, 17);
            this.txtName.Size = new System.Drawing.Size(220, 23);

            // lblDuration
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(20, 60);
            this.lblDuration.Text = "Duração (meses):";

            // numDuration
            this.numDuration.Location = new System.Drawing.Point(120, 57);
            this.numDuration.Size = new System.Drawing.Size(100, 23);
            this.numDuration.Minimum = 1;
            this.numDuration.Maximum = 120;

            // lblDescription
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(20, 100);
            this.lblDescription.Text = "Descrição:";

            // txtDescription
            this.txtDescription.Location = new System.Drawing.Point(120, 97);
            this.txtDescription.Size = new System.Drawing.Size(220, 23);
            this.txtDescription.Multiline = true;
            this.txtDescription.Height = 40;

            // chkActive
            this.chkActive.AutoSize = true;
            this.chkActive.Location = new System.Drawing.Point(120, 150);
            this.chkActive.Text = "Ativo";
            this.chkActive.Checked = true;

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(120, 180);
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.Text = "Guardar";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(240, 180);
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // WarrantyEditForm
            this.ClientSize = new System.Drawing.Size(380, 240);
            this.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblName, txtName,
                lblDuration, numDuration,
                lblDescription, txtDescription,
                chkActive, btnSave, btnCancel
            });
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Garantia";

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label lblDescription;

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.NumericUpDown numDuration;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.CheckBox chkActive;

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
