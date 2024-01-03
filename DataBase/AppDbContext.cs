using Backery.DataBase.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Backery.DataBase
{
    public class AppDbContext :IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options){ }

        public DbSet<Category> categories { get; set; }
        public DbSet<product> products { get; set; }
        public DbSet<Store> stores { get; set; }
        public DbSet<Sale> sales { get; set; }
        public DbSet<ProductSale> productSales { get; set; }


    }
}
