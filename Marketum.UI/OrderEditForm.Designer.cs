namespace Marketum.UI
{
    partial class OrderEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblOrderId;
        private Label lblCustomer;
        private Label lblDate;
        private Label lblTotal;
        private Label lblStatus;
        private ComboBox cmbStatus;
        private Button btnSave;
        private Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblOrderId = new Label();
            lblCustomer = new Label();
            lblDate = new Label();
            lblTotal = new Label();
            lblStatus = new Label();
            cmbStatus = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            
            // lblOrderId
            lblOrderId.AutoSize = true;
            lblOrderId.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            lblOrderId.Location = new Point(12, 15);
            lblOrderId.Name = "lblOrderId";
            lblOrderId.Size = new Size(100, 20);
            lblOrderId.TabIndex = 0;
            lblOrderId.Text = "Encomenda #";
            
            // lblCustomer
            lblCustomer.AutoSize = true;
            lblCustomer.Location = new Point(12, 50);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(48, 15);
            lblCustomer.TabIndex = 1;
            lblCustomer.Text = "Cliente:";
            
            // lblDate
            lblDate.AutoSize = true;
            lblDate.Location = new Point(12, 75);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(34, 15);
            lblDate.TabIndex = 2;
            lblDate.Text = "Data:";
            
            // lblTotal
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(12, 100);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(35, 15);
            lblTotal.TabIndex = 3;
            lblTotal.Text = "Total:";
            
            // lblStatus
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(12, 135);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(42, 15);
            lblStatus.TabIndex = 4;
            lblStatus.Text = "Status:";
            
            // cmbStatus
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(70, 132);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(200, 23);
            cmbStatus.TabIndex = 5;
            
            // btnSave
            btnSave.Location = new Point(114, 180);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 6;
            btnSave.Text = "Guardar";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            
            // btnCancel
            btnCancel.Location = new Point(195, 180);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            
            // OrderEditForm
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 221);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(cmbStatus);
            Controls.Add(lblStatus);
            Controls.Add(lblTotal);
            Controls.Add(lblDate);
            Controls.Add(lblCustomer);
            Controls.Add(lblOrderId);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "OrderEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Editar Encomenda";
            Load += OrderEditForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}