using System;
using Marketum.Domain;
using Marketum.Persistence;
using Marketum.Services;

namespace Marketum.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Marketum Backoffice ---");

            // Inicialização
            var accountRepo = new AccountRepository();
            var productRepo = new ProductRepository();
            var clientRepo = new ClientRepository();

            var authService = new AuthService(accountRepo);

            // Garante que existe um admin para entrar
            if (accountRepo.GetByUsername("admin") == null)
            {
                authService.Register("admin", "admin123", UserRole.Admin);
            }

            // Login
            Console.Write("Username: ");
            string user = Console.ReadLine() ?? "";
            Console.Write("Password: ");
            string pass = Console.ReadLine() ?? "";

            var currentUser = authService.Login(user, pass);

            if (currentUser == null)
            {
                Console.WriteLine("Login inválido.");
                return;
            }

            Console.WriteLine($"\nBem-vindo, {currentUser.Username}!");

            // Menu Principal
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n1. Listar Produtos");
                Console.WriteLine("2. Adicionar Produto (Teste)");
                Console.WriteLine("3. Listar Clientes");
                Console.WriteLine("0. Sair");
                Console.Write("Opção: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        var list = productRepo.GetAll();
                        Console.WriteLine($"Total: {list.Count}");
                        foreach (var p in list)
                            Console.WriteLine($"#{p.Id} {p.Name} | {p.Price} EUR | Stock: {p.Stock}");
                        break;

                    case "2":
                        var newProd = new Product(0, "Novo Produto", 15.50m, 10);
                        newProd.CategoryId = 1;
                        newProd.BrandId = 1;
                        productRepo.Add(newProd);
                        Console.WriteLine("Produto adicionado com sucesso.");
                        break;

                    case "3":
                        foreach (var c in clientRepo.GetAll())
                            Console.WriteLine($"#{c.Id} {c.Name} ({c.Email})");
                        break;

                    case "0":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }
    }
}