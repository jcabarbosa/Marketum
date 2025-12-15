namespace Marketum.UI
{
    partial class WarrantyListForm : Form
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
            this.dgvWarranties = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvWarranties)).BeginInit();
            this.SuspendLayout();

            // dgvWarranties
            this.dgvWarranties.AllowUserToAddRows = false;
            this.dgvWarranties.AllowUserToDeleteRows = false;
            this.dgvWarranties.ReadOnly = true;
            this.dgvWarranties.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWarranties.MultiSelect = false;
            this.dgvWarranties.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvWarranties.Location = new System.Drawing.Point(12, 12);
            this.dgvWarranties.Size = new System.Drawing.Size(560, 300);

            // btnAdd
            this.btnAdd.Location = new System.Drawing.Point(12, 330);
            this.btnAdd.Size = new System.Drawing.Size(90, 30);
            this.btnAdd.Text = "Adicionar";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // btnEdit
            this.btnEdit.Location = new System.Drawing.Point(120, 330);
            this.btnEdit.Size = new System.Drawing.Size(90, 30);
            this.btnEdit.Text = "Editar";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            // btnRemove
            this.btnRemove.Location = new System.Drawing.Point(230, 330);
            this.btnRemove.Size = new System.Drawing.Size(90, 30);
            this.btnRemove.Text = "Remover";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);

            // WarrantyListForm
            this.ClientSize = new System.Drawing.Size(584, 381);
            this.Controls.Add(this.dgvWarranties);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnRemove);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Garantias";
            this.Load += new System.EventHandler(this.WarrantyListForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvWarranties)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvWarranties;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnRemove;
    }
}
