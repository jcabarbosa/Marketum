namespace Marketum.UI
{
    partial class CampaignListForm : Form
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
            this.dgvCampaigns = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvCampaigns)).BeginInit();
            this.SuspendLayout();

            // dgvCampaigns
            this.dgvCampaigns.ReadOnly = true;
            this.dgvCampaigns.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCampaigns.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCampaigns.Location = new System.Drawing.Point(12, 12);
            this.dgvCampaigns.Size = new System.Drawing.Size(760, 360);

            // btnAdd
            this.btnAdd.Text = "Nova Campanha";
            this.btnAdd.Location = new System.Drawing.Point(12, 390);
            this.btnAdd.Size = new System.Drawing.Size(120, 30);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // btnRemove
            this.btnRemove.Text = "Remover";
            this.btnRemove.Location = new System.Drawing.Point(150, 390);
            this.btnRemove.Size = new System.Drawing.Size(100, 30);
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);

            // btnClose
            this.btnClose.Text = "Fechar";
            this.btnClose.Location = new System.Drawing.Point(270, 390);
            this.btnClose.Size = new System.Drawing.Size(100, 30);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // CampaignListForm
            this.ClientSize = new System.Drawing.Size(784, 441);
            this.Controls.Add(this.dgvCampaigns);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnClose);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Campanhas";
            this.Load += new System.EventHandler(this.CampaignListForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvCampaigns)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dgvCampaigns;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnClose;
    }
}