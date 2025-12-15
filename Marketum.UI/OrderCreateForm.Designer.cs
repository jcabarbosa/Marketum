namespace Marketum.UI
{
    partial class OrderCreateForm : Form
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
            this.lblClient = new System.Windows.Forms.Label();
            this.lblPayment = new System.Windows.Forms.Label();
            this.lblProduct = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();

            this.cmbClient = new System.Windows.Forms.ComboBox();
            this.cmbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.cmbProduct = new System.Windows.Forms.ComboBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();

            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.SuspendLayout();

            // lblClient
            this.lblClient.AutoSize = true;
            this.lblClient.Location = new System.Drawing.Point(20, 20);
            this.lblClient.Text = "Cliente:";

            // cmbClient
            this.cmbClient.Location = new System.Drawing.Point(100, 17);
            this.cmbClient.Size = new System.Drawing.Size(180, 23);
            this.cmbClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // lblPayment
            this.lblPayment.AutoSize = true;
            this.lblPayment.Location = new System.Drawing.Point(300, 20);
            this.lblPayment.Text = "Pagamento:";

            // cmbPaymentMethod
            this.cmbPaymentMethod.Location = new System.Drawing.Point(390, 17);
            this.cmbPaymentMethod.Size = new System.Drawing.Size(160, 23);
            this.cmbPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // lblProduct
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new System.Drawing.Point(20, 60);
            this.lblProduct.Text = "Produto:";

            // cmbProduct
            this.cmbProduct.Location = new System.Drawing.Point(100, 57);
            this.cmbProduct.Size = new System.Drawing.Size(180, 23);
            this.cmbProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // lblQuantity
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(300, 60);
            this.lblQuantity.Text = "Quantidade:";

            // txtQuantity
            this.txtQuantity.Location = new System.Drawing.Point(390, 57);
            this.txtQuantity.Size = new System.Drawing.Size(80, 23);

            // btnAddItem
            this.btnAddItem.Location = new System.Drawing.Point(490, 55);
            this.btnAddItem.Size = new System.Drawing.Size(80, 27);
            this.btnAddItem.Text = "Adicionar";
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);

            // dgvItems
            this.dgvItems.Location = new System.Drawing.Point(20, 100);
            this.dgvItems.Size = new System.Drawing.Size(550, 220);
            this.dgvItems.ReadOnly = true;
            this.dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(390, 340);
            this.btnSave.Size = new System.Drawing.Size(80, 30);
            this.btnSave.Text = "Guardar";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(490, 340);
            this.btnCancel.Size = new System.Drawing.Size(80, 30);
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // OrderCreateForm
            this.ClientSize = new System.Drawing.Size(600, 390);
            this.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblClient, cmbClient,
                lblPayment, cmbPaymentMethod,
                lblProduct, cmbProduct,
                lblQuantity, txtQuantity,
                btnAddItem,
                dgvItems,
                btnSave,
                btnCancel
            });
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nova Encomenda";

            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.Label lblPayment;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblQuantity;

        private System.Windows.Forms.ComboBox cmbClient;
        private System.Windows.Forms.ComboBox cmbPaymentMethod;
        private System.Windows.Forms.ComboBox cmbProduct;
        private System.Windows.Forms.TextBox txtQuantity;

        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
