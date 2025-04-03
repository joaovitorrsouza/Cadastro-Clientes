using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CadastroClientes
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }

    public class AppDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=clientes.db");
        }
    }

    class Program
    {
        static void Main()
        {
            using (var db = new AppDbContext())
            {
                db.Database.EnsureCreated();
            }

            while (true)
            {
                Console.WriteLine("\n1 - Cadastrar Cliente\n2 - Listar Clientes\n3 - Remover Cliente\n4 - Sair");
                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        CadastrarCliente();
                        break;
                    case "2":
                        ListarClientes();
                        break;
                    case "3":
                        RemoverCliente();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }

        static void CadastrarCliente()
        {
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();

            using (var db = new AppDbContext())
            {
                var cliente = new Cliente { Nome = nome, Email = email };
                db.Clientes.Add(cliente);
                db.SaveChanges();
            }
            Console.WriteLine("Cliente cadastrado com sucesso!");
        }

        static void ListarClientes()
        {
            using (var db = new AppDbContext())
            {
                var clientes = db.Clientes.ToList();
                foreach (var cliente in clientes)
                {
                    Console.WriteLine($"ID: {cliente.Id}, Nome: {cliente.Nome}, Email: {cliente.Email}");
                }
            }
        }

        static void RemoverCliente()
        {
            Console.Write("Informe o ID do cliente para remover: ");
            int id = int.Parse(Console.ReadLine());

            using (var db = new AppDbContext())
            {
                var cliente = db.Clientes.Find(id);
                if (cliente != null)
                {
                    db.Clientes.Remove(cliente);
                    db.SaveChanges();
                    Console.WriteLine("Cliente removido com sucesso!");
                }
                else
                {
                    Console.WriteLine("Cliente não encontrado!");
                }
            }
        }
    }
}
