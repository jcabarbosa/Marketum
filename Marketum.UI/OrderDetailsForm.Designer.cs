namespace Marketum.UI
{
    partial class OrderDetailsForm
    {
        private System.ComponentModel.IContainer components = null;

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
            this.lblOrderId = new System.Windows.Forms.Label();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblPaymentMethod = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.lblCampaign = new System.Windows.Forms.Label();
            
            this.grpClient = new System.Windows.Forms.GroupBox();
            this.lblClientName = new System.Windows.Forms.Label();
            this.lblClientEmail = new System.Windows.Forms.Label();
            this.lblClientPhone = new System.Windows.Forms.Label();
            this.lblClientAddress = new System.Windows.Forms.Label();
            
            this.grpItems = new System.Windows.Forms.GroupBox();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            
            this.btnClose = new System.Windows.Forms.Button();

            this.grpClient.SuspendLayout();
            this.grpItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.SuspendLayout();

            // lblOrderId
            this.lblOrderId.AutoSize = true;
            this.lblOrderId.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblOrderId.Location = new System.Drawing.Point(12, 15);
            this.lblOrderId.Text = "Encomenda #";

            // lblOrderDate
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.Location = new System.Drawing.Point(12, 45);
            this.lblOrderDate.Text = "Data:";

            // lblStatus
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 65);
            this.lblStatus.Text = "Estado:";

            // lblPaymentMethod
            this.lblPaymentMethod.AutoSize = true;
            this.lblPaymentMethod.Location = new System.Drawing.Point(12, 85);
            this.lblPaymentMethod.Text = "Pagamento:";

            // lblEmployee
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Location = new System.Drawing.Point(12, 105);
            this.lblEmployee.Text = "Funcionário:";

            // lblTotal
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(12, 130);
            this.lblTotal.Text = "Total:";

            // lblCampaign
            this.lblCampaign.AutoSize = true;
            this.lblCampaign.ForeColor = System.Drawing.Color.Green;
            this.lblCampaign.Location = new System.Drawing.Point(12, 155);
            this.lblCampaign.Text = "Campanha:";
            this.lblCampaign.Visible = false;

            // grpClient
            this.grpClient.Controls.Add(this.lblClientName);
            this.grpClient.Controls.Add(this.lblClientEmail);
            this.grpClient.Controls.Add(this.lblClientPhone);
            this.grpClient.Controls.Add(this.lblClientAddress);
            this.grpClient.Location = new System.Drawing.Point(12, 180);
            this.grpClient.Size = new System.Drawing.Size(560, 100);
            this.grpClient.Text = "Dados do Cliente";

            // lblClientName
            this.lblClientName.AutoSize = true;
            this.lblClientName.Location = new System.Drawing.Point(10, 20);
            this.lblClientName.Text = "Cliente:";

            // lblClientEmail
            this.lblClientEmail.AutoSize = true;
            this.lblClientEmail.Location = new System.Drawing.Point(10, 40);
            this.lblClientEmail.Text = "Email:";

            // lblClientPhone
            this.lblClientPhone.AutoSize = true;
            this.lblClientPhone.Location = new System.Drawing.Point(10, 60);
            this.lblClientPhone.Text = "Telefone:";

            // lblClientAddress
            this.lblClientAddress.AutoSize = true;
            this.lblClientAddress.Location = new System.Drawing.Point(10, 80);
            this.lblClientAddress.Text = "Morada:";

            // grpItems
            this.grpItems.Controls.Add(this.dgvItems);
            this.grpItems.Location = new System.Drawing.Point(12, 290);
            this.grpItems.Size = new System.Drawing.Size(560, 200);
            this.grpItems.Text = "Items da Encomenda";

            // dgvItems
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.ReadOnly = true;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItems.Location = new System.Drawing.Point(10, 20);
            this.dgvItems.Size = new System.Drawing.Size(540, 170);

            // btnClose
            this.btnClose.Location = new System.Drawing.Point(497, 500);
            this.btnClose.Size = new System.Drawing.Size(75, 30);
            this.btnClose.Text = "Fechar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // OrderDetailsForm
            this.ClientSize = new System.Drawing.Size(584, 542);
            this.Controls.Add(this.lblOrderId);
            this.Controls.Add(this.lblOrderDate);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblPaymentMethod);
            this.Controls.Add(this.lblEmployee);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblCampaign);
            this.Controls.Add(this.grpClient);
            this.Controls.Add(this.grpItems);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Detalhes da Encomenda";

            this.grpClient.ResumeLayout(false);
            this.grpClient.PerformLayout();
            this.grpItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblOrderId;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblPaymentMethod;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.Label lblCampaign;
        
        private System.Windows.Forms.GroupBox grpClient;
        private System.Windows.Forms.Label lblClientName;
        private System.Windows.Forms.Label lblClientEmail;
        private System.Windows.Forms.Label lblClientPhone;
        private System.Windows.Forms.Label lblClientAddress;
        
        private System.Windows.Forms.GroupBox grpItems;
        private System.Windows.Forms.DataGridView dgvItems;
        
        private System.Windows.Forms.Button btnClose;
    }
}