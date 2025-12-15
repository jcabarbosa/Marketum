using System;
using System.Windows.Forms;
using Marketum.Domain;
using Marketum.Persistence;
using Marketum.Services;
using Marketum.UI;

namespace Marketum
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // =========================
            // Repositories
            // =========================
            IClientRepository clientRepo = new ClientRepository();
            IProductRepository productRepo = new ProductRepository();
            IEmployeeRepository employeeRepo = new EmployeeRepository();
            IOrderRepository orderRepo = new OrderRepository();
            IOrderItemRepository orderItemRepo = new OrderItemRepository();
            IWarrantyRepository warrantyRepo = new WarrantyRepository();
            ICampaignRepository campaignRepo = new CampaignRepository();
            IAccountRepository accountRepo = new AccountRepository();
            IBrandRepository brandRepo = new BrandRepository();
            ICategoryRepository categoryRepo = new CategoryRepository();

            // =========================
            // Services
            // =========================
            IClientService clientService = new ClientService(clientRepo);
            IProductService productService = new ProductService(productRepo);
            IEmployeeService employeeService = new EmployeeService(employeeRepo);
            ICampaignService campaignService = new CampaignService(campaignRepo);
            IWarrantyService warrantyService = new WarrantyService(warrantyRepo);
            IBrandService brandService = new BrandService(brandRepo);
            ICategoryService categoryService = new CategoryService(categoryRepo);

            IOrderService orderService = new OrderService(
                orderRepo,
                orderItemRepo,
                productRepo,
                clientRepo,
                campaignService
            );

            IAuthService authService = new AuthService(accountRepo);

            // =========================
            // Login
            // =========================
            using var loginForm = new LoginForm(authService);
            if (loginForm.ShowDialog() != DialogResult.OK)
                return;

            Account loggedAccount = loginForm.AuthenticatedAccount;
            if (loggedAccount == null)
                return;

            // =========================
            // Main
            // =========================
            Application.Run(new MainForm(
                loggedAccount,
                clientService,
                productService,
                employeeService,
                orderService,
                authService,
                campaignService,
                brandService,
                categoryService,
                warrantyService
            ));
        }
    }
}
