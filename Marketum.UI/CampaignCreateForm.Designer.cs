namespace Marketum.UI
{
    partial class CampaignCreateForm : Form
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
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.numDiscount = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.numDiscount)).BeginInit();
            this.SuspendLayout();

            // lblName
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(20, 25);
            this.lblName.Text = "Nome:";

            // txtName
            this.txtName.Location = new System.Drawing.Point(120, 22);
            this.txtName.Size = new System.Drawing.Size(240, 23);

            // lblStartDate
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(20, 65);
            this.lblStartDate.Text = "Data Início:";

            // dtpStartDate
            this.dtpStartDate.Location = new System.Drawing.Point(120, 62);
            this.dtpStartDate.Size = new System.Drawing.Size(240, 23);

            // lblEndDate
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(20, 105);
            this.lblEndDate.Text = "Data Fim:";

            // dtpEndDate
            this.dtpEndDate.Location = new System.Drawing.Point(120, 102);
            this.dtpEndDate.Size = new System.Drawing.Size(240, 23);

            // lblDiscount
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(20, 145);
            this.lblDiscount.Text = "Desconto (%):";

            // numDiscount
            this.numDiscount.Location = new System.Drawing.Point(120, 142);
            this.numDiscount.Size = new System.Drawing.Size(100, 23);
            this.numDiscount.Minimum = 1;
            this.numDiscount.Maximum = 100;
            this.numDiscount.Value = 10;

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(120, 190);
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.Text = "Guardar";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(260, 190);
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // CampaignCreateForm
            this.ClientSize = new System.Drawing.Size(400, 250);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.numDiscount);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nova Campanha";

            ((System.ComponentModel.ISupportInitialize)(this.numDiscount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.NumericUpDown numDiscount;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}