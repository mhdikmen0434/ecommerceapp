using System.Data.Entity;
using ECommerceApp.DataAccess.Concrete.EntityFramework.Configurations;
using ECommerceApp.Entities.Concrete;

namespace ECommerceApp.DataAccess.Concrete.EntityFramework.Contexts
{
    public class ECommerceAppContext : DbContext
    {
        public ECommerceAppContext() : base(@"Server=DESKTOP-A8MUS1G\SQLEXPRESS;Database=ECommerceApp;Trusted_Connection=True;")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> BasketProducts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new CartConfiguration());
        }
    }
}
