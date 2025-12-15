namespace Marketum.UI
{
    partial class MainForm : Form
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
            menuStrip1 = new MenuStrip();
            menuSistema = new ToolStripMenuItem();
            menuSair = new ToolStripMenuItem();
            menuGestaoprodutos = new ToolStripMenuItem();
            menuMarcas = new ToolStripMenuItem();
            menuCategorias = new ToolStripMenuItem();
            menuGarantias = new ToolStripMenuItem();
            menuProdutos = new ToolStripMenuItem();
            menuStock = new ToolStripMenuItem();
            menuClientes = new ToolStripMenuItem();
            menuEncomendas = new ToolStripMenuItem();
            menuNovaEncomenda = new ToolStripMenuItem();
            menuListaEncomendas = new ToolStripMenuItem();
            menuCampanhas = new ToolStripMenuItem();
            menuListarCampanhas = new ToolStripMenuItem();
            menuCriarCampanha = new ToolStripMenuItem();
            menuAdministracao = new ToolStripMenuItem();
            menuFuncionarios = new ToolStripMenuItem();
            menuCriarConta = new ToolStripMenuItem();
            menuListarContas = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            lblUserInfo = new ToolStripStatusLabel();
            panelWelcome = new Panel();
            lblWelcome = new Label();
            lblInstructions = new Label();
            panelStats = new Panel();
            lblStatsTitle = new Label();
            lblTotalOrders = new Label();
            lblTotalClients = new Label();
            lblTotalProducts = new Label();
            panelQuickActions = new Panel();
            lblQuickActionsTitle = new Label();
            btnQuickNewOrder = new Button();
            btnQuickViewOrders = new Button();
            btnQuickManageStock = new Button();
            btnQuickViewClients = new Button();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            panelWelcome.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuSistema, menuGestaoprodutos, menuClientes, menuEncomendas, menuCampanhas, menuAdministracao });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(900, 24);
            menuStrip1.TabIndex = 0;
            // 
            // menuSistema
            // 
            menuSistema.DropDownItems.AddRange(new ToolStripItem[] { menuSair });
            menuSistema.Name = "menuSistema";
            menuSistema.Size = new Size(60, 20);
            menuSistema.Text = "Sistema";
            // 
            // menuSair
            // 
            menuSair.Name = "menuSair";
            menuSair.Size = new Size(180, 22);
            menuSair.Text = "Sair";
            menuSair.Click += menuSair_Click;
            // 
            // menuGestaoprodutos
            // 
            menuGestaoprodutos.DropDownItems.AddRange(new ToolStripItem[] { menuMarcas, menuCategorias, menuGarantias, menuProdutos, menuStock });
            menuGestaoprodutos.Name = "menuGestaoprodutos";
            menuGestaoprodutos.Size = new Size(130, 20);
            menuGestaoprodutos.Text = "Gestão de Produtos";
            // 
            // menuMarcas
            // 
            menuMarcas.Name = "menuMarcas";
            menuMarcas.Size = new Size(180, 22);
            menuMarcas.Text = "Marcas";
            menuMarcas.Click += menuMarcas_Click;
            // 
            // menuCategorias
            // 
            menuCategorias.Name = "menuCategorias";
            menuCategorias.Size = new Size(180, 22);
            menuCategorias.Text = "Categorias";
            menuCategorias.Click += menuCategorias_Click;
            // 
            // menuGarantias
            // 
            menuGarantias.Name = "menuGarantias";
            menuGarantias.Size = new Size(180, 22);
            menuGarantias.Text = "Garantias";
            menuGarantias.Click += menuGarantias_Click;
            // 
            // menuProdutos
            // 
            menuProdutos.Name = "menuProdutos";
            menuProdutos.Size = new Size(180, 22);
            menuProdutos.Text = "Produtos";
            menuProdutos.Click += menuProdutos_Click;
            // 
            // menuStock
            // 
            menuStock.Name = "menuStock";
            menuStock.Size = new Size(180, 22);
            menuStock.Text = "Gestão de Stock";
            menuStock.Click += menuStock_Click;
            // 
            // menuClientes
            // 
            menuClientes.Name = "menuClientes";
            menuClientes.Size = new Size(61, 20);
            menuClientes.Text = "Clientes";
            menuClientes.Click += menuClientes_Click;
            // 
            // menuEncomendas
            // 
            menuEncomendas.DropDownItems.AddRange(new ToolStripItem[] { menuNovaEncomenda, menuListaEncomendas });
            menuEncomendas.Name = "menuEncomendas";
            menuEncomendas.Size = new Size(87, 20);
            menuEncomendas.Text = "Encomendas";
            // 
            // menuNovaEncomenda
            // 
            menuNovaEncomenda.Name = "menuNovaEncomenda";
            menuNovaEncomenda.Size = new Size(185, 22);
            menuNovaEncomenda.Text = "Nova Encomenda";
            menuNovaEncomenda.Click += menuNovaEncomenda_Click;
            // 
            // menuListaEncomendas
            // 
            menuListaEncomendas.Name = "menuListaEncomendas";
            menuListaEncomendas.Size = new Size(185, 22);
            menuListaEncomendas.Text = "Lista de Encomendas";
            menuListaEncomendas.Click += menuListaEncomendas_Click;
            // 
            // menuCampanhas
            // 
            menuCampanhas.DropDownItems.AddRange(new ToolStripItem[] { menuListarCampanhas, menuCriarCampanha });
            menuCampanhas.Name = "menuCampanhas";
            menuCampanhas.Size = new Size(82, 20);
            menuCampanhas.Text = "Campanhas";
            // 
            // menuListarCampanhas
            // 
            menuListarCampanhas.Name = "menuListarCampanhas";
            menuListarCampanhas.Size = new Size(180, 22);
            menuListarCampanhas.Text = "Listar Campanhas";
            menuListarCampanhas.Click += menuListarCampanhas_Click;
            // 
            // menuCriarCampanha
            // 
            menuCriarCampanha.Name = "menuCriarCampanha";
            menuCriarCampanha.Size = new Size(180, 22);
            menuCriarCampanha.Text = "Criar Campanha";
            menuCriarCampanha.Click += menuCriarCampanha_Click;
            // 
            // menuAdministracao
            // 
            menuAdministracao.DropDownItems.AddRange(new ToolStripItem[] { menuFuncionarios, menuCriarConta, menuListarContas });
            menuAdministracao.Name = "menuAdministracao";
            menuAdministracao.Size = new Size(100, 20);
            menuAdministracao.Text = "Administração";
            // 
            // menuFuncionarios
            // 
            menuFuncionarios.Name = "menuFuncionarios";
            menuFuncionarios.Size = new Size(180, 22);
            menuFuncionarios.Text = "Funcionários";
            menuFuncionarios.Click += menuFuncionarios_Click;
            // 
            // menuCriarConta
            // 
            menuCriarConta.Name = "menuCriarConta";
            menuCriarConta.Size = new Size(180, 22);
            menuCriarConta.Text = "Criar Conta";
            menuCriarConta.Click += menuCriarConta_Click;
            // 
            // menuListarContas
            // 
            menuListarContas.Name = "menuListarContas";
            menuListarContas.Size = new Size(180, 22);
            menuListarContas.Text = "Listar Contas";
            menuListarContas.Click += menuListarContas_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblUserInfo });
            statusStrip1.Location = new Point(0, 578);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(900, 22);
            statusStrip1.TabIndex = 1;
            // 
            // lblUserInfo
            // 
            lblUserInfo.Name = "lblUserInfo";
            lblUserInfo.Size = new Size(60, 17);
            lblUserInfo.Text = "Utilizador:";
            // 
            // panelWelcome
            // 
            panelWelcome.Controls.Add(lblWelcome);
            panelWelcome.Controls.Add(lblInstructions);
            panelWelcome.Location = new Point(20, 40);
            panelWelcome.Size = new Size(860, 120);
            panelWelcome.BackColor = Color.FromArgb(41, 128, 185);
            panelWelcome.ForeColor = Color.White;
            panelWelcome.Padding = new Padding(20);
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.White;
            lblWelcome.Location = new Point(20, 20);
            lblWelcome.Text = "Bem-vindo ao Marketum!";
            // 
            // lblInstructions
            // 
            lblInstructions.AutoSize = true;
            lblInstructions.Font = new Font("Segoe UI", 14F);
            lblInstructions.ForeColor = Color.White;
            lblInstructions.Location = new Point(20, 70);
            lblInstructions.Text = "Sistema de Gestão de Lojas Online - Utilize o menu ou ações rápidas abaixo";
            // 
            // panelStats
            // 
            panelStats.Controls.Add(lblStatsTitle);
            panelStats.Controls.Add(lblTotalOrders);
            panelStats.Controls.Add(lblTotalClients);
            panelStats.Controls.Add(lblTotalProducts);
            panelStats.Location = new Point(20, 180);
            panelStats.Size = new Size(420, 200);
            panelStats.BackColor = Color.FromArgb(46, 204, 113);
            panelStats.ForeColor = Color.White;
            panelStats.Padding = new Padding(20);
            
            // lblStatsTitle
            // 
            lblStatsTitle.AutoSize = true;
            lblStatsTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblStatsTitle.ForeColor = Color.White;
            lblStatsTitle.Location = new Point(20, 20);
            lblStatsTitle.Text = "Estatísticas do Sistema";
            
            // lblTotalOrders
            // 
            lblTotalOrders.AutoSize = true;
            lblTotalOrders.Font = new Font("Segoe UI", 12F);
            lblTotalOrders.ForeColor = Color.White;
            lblTotalOrders.Location = new Point(20, 60);
            lblTotalOrders.Text = "Total de Encomendas: 0";
            
            // lblTotalClients
            // 
            lblTotalClients.AutoSize = true;
            lblTotalClients.Font = new Font("Segoe UI", 12F);
            lblTotalClients.ForeColor = Color.White;
            lblTotalClients.Location = new Point(20, 90);
            lblTotalClients.Text = "Total de Clientes: 0";
            
            // lblTotalProducts
            // 
            lblTotalProducts.AutoSize = true;
            lblTotalProducts.Font = new Font("Segoe UI", 12F);
            lblTotalProducts.ForeColor = Color.White;
            lblTotalProducts.Location = new Point(20, 120);
            lblTotalProducts.Text = "Total de Produtos: 0";
            
            // panelQuickActions
            // 
            panelQuickActions.Controls.Add(lblQuickActionsTitle);
            panelQuickActions.Controls.Add(btnQuickNewOrder);
            panelQuickActions.Controls.Add(btnQuickViewOrders);
            panelQuickActions.Controls.Add(btnQuickManageStock);
            panelQuickActions.Controls.Add(btnQuickViewClients);
            panelQuickActions.Location = new Point(460, 180);
            panelQuickActions.Size = new Size(420, 200);
            panelQuickActions.BackColor = Color.FromArgb(155, 89, 182);
            panelQuickActions.ForeColor = Color.White;
            panelQuickActions.Padding = new Padding(20);
            
            // lblQuickActionsTitle
            // 
            lblQuickActionsTitle.AutoSize = true;
            lblQuickActionsTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblQuickActionsTitle.ForeColor = Color.White;
            lblQuickActionsTitle.Location = new Point(20, 20);
            lblQuickActionsTitle.Text = "Ações Rápidas";
            
            // btnQuickNewOrder
            // 
            btnQuickNewOrder.BackColor = Color.FromArgb(52, 73, 94);
            btnQuickNewOrder.FlatStyle = FlatStyle.Flat;
            btnQuickNewOrder.ForeColor = Color.White;
            btnQuickNewOrder.Location = new Point(20, 60);
            btnQuickNewOrder.Size = new Size(180, 35);
            btnQuickNewOrder.Text = "Nova Encomenda";
            btnQuickNewOrder.UseVisualStyleBackColor = false;
            btnQuickNewOrder.Click += (s, e) => menuNewOrder_Click(s, e);
            
            // btnQuickViewOrders
            // 
            btnQuickViewOrders.BackColor = Color.FromArgb(52, 73, 94);
            btnQuickViewOrders.FlatStyle = FlatStyle.Flat;
            btnQuickViewOrders.ForeColor = Color.White;
            btnQuickViewOrders.Location = new Point(220, 60);
            btnQuickViewOrders.Size = new Size(180, 35);
            btnQuickViewOrders.Text = "Ver Encomendas";
            btnQuickViewOrders.UseVisualStyleBackColor = false;
            btnQuickViewOrders.Click += (s, e) => menuOrdersList_Click(s, e);
            
            // btnQuickManageStock
            // 
            btnQuickManageStock.BackColor = Color.FromArgb(52, 73, 94);
            btnQuickManageStock.FlatStyle = FlatStyle.Flat;
            btnQuickManageStock.ForeColor = Color.White;
            btnQuickManageStock.Location = new Point(20, 110);
            btnQuickManageStock.Size = new Size(180, 35);
            btnQuickManageStock.Text = "Gestão de Stock";
            btnQuickManageStock.UseVisualStyleBackColor = false;
            btnQuickManageStock.Click += (s, e) => menuStock_Click(s, e);
            
            // btnQuickViewClients
            // 
            btnQuickViewClients.BackColor = Color.FromArgb(52, 73, 94);
            btnQuickViewClients.FlatStyle = FlatStyle.Flat;
            btnQuickViewClients.ForeColor = Color.White;
            btnQuickViewClients.Location = new Point(220, 110);
            btnQuickViewClients.Size = new Size(180, 35);
            btnQuickViewClients.Text = "Ver Clientes";
            btnQuickViewClients.UseVisualStyleBackColor = false;
            btnQuickViewClients.Click += (s, e) => menuClientes_Click(s, e);
            
            // MainForm
            // 
            ClientSize = new Size(900, 600);
            BackColor = Color.FromArgb(236, 240, 241);
            Controls.Add(panelWelcome);
            Controls.Add(panelStats);
            Controls.Add(panelQuickActions);
            Controls.Add(menuStrip1);
            Controls.Add(statusStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Marketum";
            Load += MainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            panelWelcome.ResumeLayout(false);
            panelWelcome.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuSistema;
        private System.Windows.Forms.ToolStripMenuItem menuSair;

        private System.Windows.Forms.ToolStripMenuItem menuGestaoprodutos;
        private System.Windows.Forms.ToolStripMenuItem menuMarcas;
        private System.Windows.Forms.ToolStripMenuItem menuCategorias;
        private System.Windows.Forms.ToolStripMenuItem menuGarantias;
        private System.Windows.Forms.ToolStripMenuItem menuProdutos;
        private System.Windows.Forms.ToolStripMenuItem menuStock;
        private System.Windows.Forms.ToolStripMenuItem menuClientes;

        private System.Windows.Forms.ToolStripMenuItem menuEncomendas;
        private System.Windows.Forms.ToolStripMenuItem menuNovaEncomenda;
        private System.Windows.Forms.ToolStripMenuItem menuListaEncomendas;

        private System.Windows.Forms.ToolStripMenuItem menuCampanhas;
        private System.Windows.Forms.ToolStripMenuItem menuListarCampanhas;
        private System.Windows.Forms.ToolStripMenuItem menuCriarCampanha;

        private System.Windows.Forms.ToolStripMenuItem menuAdministracao;
        private System.Windows.Forms.ToolStripMenuItem menuFuncionarios;
        private System.Windows.Forms.ToolStripMenuItem menuCriarConta;
        private System.Windows.Forms.ToolStripMenuItem menuListarContas;

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblUserInfo;
        
        private System.Windows.Forms.Panel panelWelcome;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblInstructions;
        
        private System.Windows.Forms.Panel panelStats;
        private System.Windows.Forms.Label lblStatsTitle;
        private System.Windows.Forms.Label lblTotalOrders;
        private System.Windows.Forms.Label lblTotalClients;
        private System.Windows.Forms.Label lblTotalProducts;
        
        private System.Windows.Forms.Panel panelQuickActions;
        private System.Windows.Forms.Label lblQuickActionsTitle;
        private System.Windows.Forms.Button btnQuickNewOrder;
        private System.Windows.Forms.Button btnQuickViewOrders;
        private System.Windows.Forms.Button btnQuickManageStock;
        private System.Windows.Forms.Button btnQuickViewClients;
    }
}
