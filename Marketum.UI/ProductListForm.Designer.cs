namespace Marketum.UI
{
    partial class ProductListForm : Form
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
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();

            // dgvProducts
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.Location = new System.Drawing.Point(12, 12);
            this.dgvProducts.Size = new System.Drawing.Size(760, 380);

            // btnAdd
            this.btnAdd.Location = new System.Drawing.Point(12, 410);
            this.btnAdd.Size = new System.Drawing.Size(100, 30);
            this.btnAdd.Text = "Adicionar";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // btnEdit
            this.btnEdit.Location = new System.Drawing.Point(130, 410);
            this.btnEdit.Size = new System.Drawing.Size(100, 30);
            this.btnEdit.Text = "Editar";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            // btnRemove
            this.btnRemove.Location = new System.Drawing.Point(250, 410);
            this.btnRemove.Size = new System.Drawing.Size(100, 30);
            this.btnRemove.Text = "Remover";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);

            // ProductListForm
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnRemove);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Produtos";
            this.Load += new System.EventHandler(this.ProductListForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnRemove;
    }
}
