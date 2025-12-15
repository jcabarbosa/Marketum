namespace Marketum.UI
{
    partial class StockForm : Form
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
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.btnUpdateStock = new System.Windows.Forms.Button();

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
            this.dgvProducts.Size = new System.Drawing.Size(760, 340);

            // lblQuantity
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(12, 370);
            this.lblQuantity.Text = "Quantidade (+/-):";

            // txtQuantity
            this.txtQuantity.Location = new System.Drawing.Point(140, 367);
            this.txtQuantity.Size = new System.Drawing.Size(120, 23);

            // btnUpdateStock
            this.btnUpdateStock.Location = new System.Drawing.Point(280, 365);
            this.btnUpdateStock.Size = new System.Drawing.Size(120, 27);
            this.btnUpdateStock.Text = "Actualizar Stock";
            this.btnUpdateStock.Click += new System.EventHandler(this.btnUpdateStock_Click);

            // StockForm
            this.ClientSize = new System.Drawing.Size(784, 421);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.btnUpdateStock);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gestão de Stock";
            this.Load += new System.EventHandler(this.StockForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Button btnUpdateStock;
    }
}
