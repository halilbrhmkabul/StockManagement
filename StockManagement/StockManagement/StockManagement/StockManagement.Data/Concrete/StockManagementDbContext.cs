using Microsoft.EntityFrameworkCore;
using StockManagement.Entity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StockManagement.Data.Concrete
{
    public class StockManagementDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=HALILKABUL\SQLEXPRESS;Database=StockManagementDb;integrated security=true");
        }


        public DbSet<Currency> Currencies { get; set; }
        public DbSet<QuantityUnit> QuantityUnits { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<StockType> StockTypes { get; set; }
        public DbSet<StockUnit> StockUnits { get; set; }
        public DbSet<StockClasses> StockClasses { get; set; }


    }
}
