namespace Marketum.UI
{
    partial class BrandListForm : Form
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
            this.dgvBrands = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvBrands)).BeginInit();
            this.SuspendLayout();

            // dgvBrands
            this.dgvBrands.AllowUserToAddRows = false;
            this.dgvBrands.AllowUserToDeleteRows = false;
            this.dgvBrands.ReadOnly = true;
            this.dgvBrands.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBrands.MultiSelect = false;
            this.dgvBrands.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBrands.Location = new System.Drawing.Point(12, 12);
            this.dgvBrands.Size = new System.Drawing.Size(460, 280);

            // btnAdd
            this.btnAdd.Location = new System.Drawing.Point(12, 310);
            this.btnAdd.Size = new System.Drawing.Size(90, 30);
            this.btnAdd.Text = "Adicionar";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // btnEdit
            this.btnEdit.Location = new System.Drawing.Point(120, 310);
            this.btnEdit.Size = new System.Drawing.Size(90, 30);
            this.btnEdit.Text = "Editar";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            // btnRemove
            this.btnRemove.Location = new System.Drawing.Point(230, 310);
            this.btnRemove.Size = new System.Drawing.Size(90, 30);
            this.btnRemove.Text = "Remover";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);

            // BrandListForm
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.dgvBrands);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnRemove);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Marcas";
            this.Load += new System.EventHandler(this.BrandListForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvBrands)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBrands;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnRemove;
    }
}
