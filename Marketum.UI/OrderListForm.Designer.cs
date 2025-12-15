namespace Marketum.UI
{
    partial class OrderListForm : Form
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();

            // dgvOrders
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrders.Location = new System.Drawing.Point(12, 12);
            this.dgvOrders.Size = new System.Drawing.Size(760, 360);

            // btnEdit
            this.btnEdit.Text = "Editar";
            this.btnEdit.Location = new System.Drawing.Point(12, 390);
            this.btnEdit.Size = new System.Drawing.Size(100, 30);
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            // btnRemove
            this.btnRemove.Text = "Remover";
            this.btnRemove.Location = new System.Drawing.Point(130, 390);
            this.btnRemove.Size = new System.Drawing.Size(100, 30);
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);

            // btnStatus
            this.btnStatus = new System.Windows.Forms.Button();
            this.btnStatus.Text = "Alterar Status";
            this.btnStatus.Location = new System.Drawing.Point(250, 390);
            this.btnStatus.Size = new System.Drawing.Size(100, 30);
            this.btnStatus.Click += new System.EventHandler(this.btnStatus_Click);

            // btnDetails
            this.btnDetails = new System.Windows.Forms.Button();
            this.btnDetails.Text = "Detalhes";
            this.btnDetails.Location = new System.Drawing.Point(370, 390);
            this.btnDetails.Size = new System.Drawing.Size(100, 30);
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);

            // btnClose
            this.btnClose.Text = "Fechar";
            this.btnClose.Location = new System.Drawing.Point(490, 390);
            this.btnClose.Size = new System.Drawing.Size(100, 30);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // OrderListForm
            this.ClientSize = new System.Drawing.Size(784, 441);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnStatus);
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.btnClose);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Encomendas";
            this.Load += new System.EventHandler(this.OrderListForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnStatus;
        private System.Windows.Forms.Button btnDetails;
        private System.Windows.Forms.Button btnClose;
    }
}
