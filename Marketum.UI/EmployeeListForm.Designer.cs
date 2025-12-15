namespace Marketum.UI
{
    partial class EmployeeListForm : Form
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            this.SuspendLayout();

            this.dgvEmployees.ReadOnly = true;
            this.dgvEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmployees.Location = new System.Drawing.Point(12, 12);
            this.dgvEmployees.Size = new System.Drawing.Size(760, 360);

            this.btnAdd.Text = "Adicionar";
            this.btnAdd.Location = new System.Drawing.Point(12, 390);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnEdit.Text = "Editar";
            this.btnEdit.Location = new System.Drawing.Point(130, 390);
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            this.btnRemove.Text = "Remover";
            this.btnRemove.Location = new System.Drawing.Point(250, 390);
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);

            this.ClientSize = new System.Drawing.Size(784, 441);
            this.Controls.Add(this.dgvEmployees);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnRemove);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Funcionários";
            this.Load += new System.EventHandler(this.EmployeeListForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dgvEmployees;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnRemove;
    }
}
