namespace Marketum.UI
{
    partial class ProductEditForm : Form
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
            this.lblName = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblWarranty = new System.Windows.Forms.Label();

            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtStock = new System.Windows.Forms.TextBox();

            this.cmbBrand = new System.Windows.Forms.ComboBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.cmbWarranty = new System.Windows.Forms.ComboBox();

            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // lblName
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(20, 20);
            this.lblName.Text = "Nome:";

            // txtName
            this.txtName.Location = new System.Drawing.Point(120, 17);
            this.txtName.Size = new System.Drawing.Size(220, 23);

            // lblPrice
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(20, 60);
            this.lblPrice.Text = "Preço:";

            // txtPrice
            this.txtPrice.Location = new System.Drawing.Point(120, 57);
            this.txtPrice.Size = new System.Drawing.Size(220, 23);

            // lblStock
            this.lblStock.AutoSize = true;
            this.lblStock.Location = new System.Drawing.Point(20, 100);
            this.lblStock.Text = "Stock:";

            // txtStock
            this.txtStock.Location = new System.Drawing.Point(120, 97);
            this.txtStock.Size = new System.Drawing.Size(220, 23);

            // lblBrand
            this.lblBrand.AutoSize = true;
            this.lblBrand.Location = new System.Drawing.Point(20, 140);
            this.lblBrand.Text = "Marca:";

            // cmbBrand
            this.cmbBrand.Location = new System.Drawing.Point(120, 137);
            this.cmbBrand.Size = new System.Drawing.Size(220, 23);
            this.cmbBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // lblCategory
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(20, 180);
            this.lblCategory.Text = "Categoria:";

            // cmbCategory
            this.cmbCategory.Location = new System.Drawing.Point(120, 177);
            this.cmbCategory.Size = new System.Drawing.Size(220, 23);
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // lblWarranty
            this.lblWarranty.AutoSize = true;
            this.lblWarranty.Location = new System.Drawing.Point(20, 220);
            this.lblWarranty.Text = "Garantia:";

            // cmbWarranty
            this.cmbWarranty.Location = new System.Drawing.Point(120, 217);
            this.cmbWarranty.Size = new System.Drawing.Size(220, 23);
            this.cmbWarranty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(120, 270);
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.Text = "Guardar";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(240, 270);
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // ProductEditForm
            this.ClientSize = new System.Drawing.Size(380, 330);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.lblBrand);
            this.Controls.Add(this.cmbBrand);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lblWarranty);
            this.Controls.Add(this.cmbWarranty);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Produto";

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblWarranty;

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtStock;

        private System.Windows.Forms.ComboBox cmbBrand;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.ComboBox cmbWarranty;

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
