using System;
using System.Windows.Forms;
using Marketum.Domain;
using Marketum.Services;

namespace Marketum.UI
{
    public partial class MainForm : Form
    {
        private readonly Account _account;
        private readonly IClientService _clientService;
        private readonly IProductService _productService;
        private readonly IEmployeeService _employeeService;
        private readonly IOrderService _orderService;
        private readonly IAuthService _authService;
        private readonly ICampaignService _campaignService;
        private readonly IBrandService _brandService;
        private readonly ICategoryService _categoryService;
        private readonly IWarrantyService _warrantyService;

        public MainForm(
            Account account,
            IClientService clientService,
            IProductService productService,
            IEmployeeService employeeService,
            IOrderService orderService,
            IAuthService authService,
            ICampaignService campaignService,
            IBrandService brandService,
            ICategoryService categoryService,
            IWarrantyService warrantyService)
        {
            InitializeComponent();

            _account = account;
            _clientService = clientService;
            _productService = productService;
            _employeeService = employeeService;
            _orderService = orderService;
            _authService = authService;
            _campaignService = campaignService;
            _brandService = brandService;
            _categoryService = categoryService;
            _warrantyService = warrantyService;

            ConfigurePermissions();
        }

        private void ConfigurePermissions()
        {
            if (_account.Role != UserRole.Admin)
            {
                menuAdministracao.Enabled = false;
            }
            
            // Configurar tooltips
            var toolTip = new ToolTip();
            toolTip.SetToolTip(menuStrip1, "Use F5 para atualizar dados");
            
            // Configurar atalhos globais
            KeyPreview = true;
            KeyDown += MainForm_KeyDown;
        }

        private void menuNewOrder_Click(object sender, EventArgs e)
        {
            using var form = new OrderCreateForm(
                _orderService,
                _clientService,
                _productService,
                _account
            );
            form.ShowDialog();
        }

        private void menuOrdersList_Click(object sender, EventArgs e)
        {
            using var form = new OrderListForm(_orderService, _clientService, _productService, _employeeService);
            form.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblUserInfo.Text = $"Utilizador: {_account.Username} ({_account.Role})";
            
            lblWelcome.Text = $"Bem-vindo ao Marketum, {_account.Username}!";
            
            LoadStatistics();
        }

        private void menuSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuMarcas_Click(object sender, EventArgs e)
        {
            using var form = new BrandListForm(_brandService);
            form.ShowDialog();
        }

        private void menuCategorias_Click(object sender, EventArgs e)
        {
            using var form = new CategoryListForm(_categoryService);
            form.ShowDialog();
        }

        private void menuGarantias_Click(object sender, EventArgs e)
        {
            using var form = new WarrantyListForm(_warrantyService, _productService);
            form.ShowDialog();
        }

        private void menuProdutos_Click(object sender, EventArgs e)
        {
            using var form = new ProductListForm(_productService, _brandService, _categoryService, _warrantyService);
            form.ShowDialog();
        }
        
        private void menuStock_Click(object sender, EventArgs e)
        {
            using var form = new StockForm(_productService);
            form.ShowDialog();
        }

        private void menuClientes_Click(object sender, EventArgs e)
        {
            using var form = new ClientListForm(_clientService);
            form.ShowDialog();
        }

        private void menuNovaEncomenda_Click(object sender, EventArgs e)
        {
            menuNewOrder_Click(sender, e);
        }

        private void menuListaEncomendas_Click(object sender, EventArgs e)
        {
            using var form = new OrderListForm(_orderService, _clientService, _productService, _employeeService);
            form.ShowDialog();
        }

        private void menuListarCampanhas_Click(object sender, EventArgs e)
        {
            using var form = new CampaignListForm(_campaignService);
            form.ShowDialog();
        }

        private void menuCriarCampanha_Click(object sender, EventArgs e)
        {
            using var form = new CampaignCreateForm(_campaignService);
            form.ShowDialog();
        }

        private void menuFuncionarios_Click(object sender, EventArgs e)
        {
            using var form = new EmployeeListForm(_employeeService);
            form.ShowDialog();
        }

        private void menuCriarConta_Click(object sender, EventArgs e)
        {
            using var form = new AccountEditForm(_authService, _employeeService);
            form.ShowDialog();
        }

        private void menuListarContas_Click(object sender, EventArgs e)
        {
            using var form = new AccountListForm(_authService, _employeeService);
            form.ShowDialog();
        }
        
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Atalhos globais
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.N: // Ctrl+N - Nova encomenda
                        menuNewOrder_Click(sender, EventArgs.Empty);
                        e.Handled = true;
                        break;
                    case Keys.P: // Ctrl+P - Produtos
                        menuProdutos_Click(sender, EventArgs.Empty);
                        e.Handled = true;
                        break;
                    case Keys.C: // Ctrl+C - Clientes
                        menuClientes_Click(sender, EventArgs.Empty);
                        e.Handled = true;
                        break;
                    case Keys.S: // Ctrl+S - Stock
                        menuStock_Click(sender, EventArgs.Empty);
                        e.Handled = true;
                        break;
                }
            }
            else if (e.KeyCode == Keys.F5)
            {
                // F5 - Atualizar informações e estatísticas
                lblUserInfo.Text = $"Utilizador: {_account.Username} ({_account.Role}) - Atualizado: {DateTime.Now:HH:mm:ss}";
                LoadStatistics();
                e.Handled = true;
            }
        }
        
        private void LoadStatistics()
        {
            try
            {
                var totalOrders = _orderService.GetAllOrders().Count;
                var totalClients = _clientService.GetAllClients().Count;
                var totalProducts = _productService.GetAllProducts().Count;
                
                lblTotalOrders.Text = $"Total de Encomendas: {totalOrders}";
                lblTotalClients.Text = $"Total de Clientes: {totalClients}";
                lblTotalProducts.Text = $"Total de Produtos: {totalProducts}";
                
                // Adicionar informação de produtos com stock baixo
                var lowStockProducts = _productService.GetAllProducts().Count(p => p.Stock <= 5);
                if (lowStockProducts > 0)
                {
                    lblTotalProducts.Text += $" (⚠️ {lowStockProducts} com stock baixo)";
                    lblTotalProducts.ForeColor = Color.Yellow;
                }
                else
                {
                    lblTotalProducts.ForeColor = Color.White;
                }
            }
            catch
            {
                // Em caso de erro, manter valores padrão
            }
        }
    }
}
