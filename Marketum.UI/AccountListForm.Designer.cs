namespace Marketum.UI
{
    partial class AccountListForm : Form
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
            this.dgvAccounts = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).BeginInit();
            this.SuspendLayout();

            this.dgvAccounts.ReadOnly = true;
            this.dgvAccounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAccounts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAccounts.Location = new System.Drawing.Point(12, 12);
            this.dgvAccounts.Size = new System.Drawing.Size(560, 300);

            this.btnAdd.Text = "Adicionar";
            this.btnAdd.Location = new System.Drawing.Point(12, 330);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnEdit.Text = "Editar";
            this.btnEdit.Location = new System.Drawing.Point(120, 330);
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            this.btnRemove.Text = "Remover";
            this.btnRemove.Location = new System.Drawing.Point(230, 330);
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);

            this.ClientSize = new System.Drawing.Size(584, 381);
            this.Controls.Add(this.dgvAccounts);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnRemove);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Contas de Acesso";
            this.Load += new System.EventHandler(this.AccountListForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dgvAccounts;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnRemove;
    }
}
