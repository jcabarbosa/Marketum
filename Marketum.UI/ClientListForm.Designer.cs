namespace Marketum.UI
{
    partial class ClientListForm : Form
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
            this.dgvClients = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).BeginInit();
            this.SuspendLayout();

            // dgvClients
            this.dgvClients.AllowUserToAddRows = false;
            this.dgvClients.AllowUserToDeleteRows = false;
            this.dgvClients.ReadOnly = true;
            this.dgvClients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClients.MultiSelect = false;
            this.dgvClients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClients.Location = new System.Drawing.Point(12, 12);
            this.dgvClients.Size = new System.Drawing.Size(760, 360);

            // btnAdd
            this.btnAdd.Location = new System.Drawing.Point(12, 390);
            this.btnAdd.Size = new System.Drawing.Size(100, 30);
            this.btnAdd.Text = "Adicionar";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // btnEdit
            this.btnEdit.Location = new System.Drawing.Point(130, 390);
            this.btnEdit.Size = new System.Drawing.Size(100, 30);
            this.btnEdit.Text = "Editar";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            // btnRemove
            this.btnRemove.Location = new System.Drawing.Point(250, 390);
            this.btnRemove.Size = new System.Drawing.Size(100, 30);
            this.btnRemove.Text = "Remover";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);

            // ClientListForm
            this.ClientSize = new System.Drawing.Size(784, 441);
            this.Controls.Add(this.dgvClients);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnRemove);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Clientes";
            this.Load += new System.EventHandler(this.ClientListForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvClients;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnRemove;
    }
}
