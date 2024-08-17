using System.Configuration;
using Microsoft.EntityFrameworkCore;
using MiniProj2InventoryManagementSys.Models;

namespace MiniProj2InventoryManagementSys.DataFolder
{
    internal class InventoryContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<Inventory> Inventories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.AppSettings["connectionString"]);
        }
    }
}
