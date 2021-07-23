﻿using DataTransfertObject;
using DataTransfertObject.DataGridView;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class StockContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<LoginSession> LoginSessions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductStock> ProductStocks { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<ProductLine> ProductLines { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<GiftCheque> GiftCheques { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Address> Addresses { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _ = optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\raikh\StockDB.mdf;Integrated Security=True;Connect Timeout=30");
        }
    }
}
