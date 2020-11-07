using ECommerceApp.Entities.Concrete;

namespace ECommerceApp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ECommerceApp.DataAccess.Concrete.EntityFramework.Contexts.ECommerceAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ECommerceApp.DataAccess.Concrete.EntityFramework.Contexts.ECommerceAppContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.


            context.Products.AddOrUpdate(c => c.Name, 
                new Product { Id = 1, ImageLocation = "/Images/Products/fe9d8449-0e87-4a78-a732-ce61af352ebc.jpg", Name = "Finish Quantum Max Bulaşık Makinesi Deterjanı 116 Kapsül 58 x 2", UnitsInStock = 50, Price = 114.9M },
                new Product { Id = 2, ImageLocation = "/Images/Products/c616c110-1eea-437d-8b07-f772c5115b62.jpg", Name = "Xiaomi Mi Pro 2 Elektrikli Scooter", UnitsInStock = 50, Price = 4649M },
                new Product { Id = 3, ImageLocation = "/Images/Products/019a30ff-497a-4ab0-979d-b8429e87d81d.jpg", Name = "Asus X509JA-BR089T Intel Core i3 1005G1 4GB 256GB SSD Windows 10 Home 15.6\" Taşınabilir Bilgisayar", UnitsInStock = 50, Price = 5593.82M },
                new Product { Id = 4, ImageLocation = "/Images/Products/25804060-3cb4-4d94-8396-e6c3bf02b100.jpg", Name = "JBL Go 2 IPX7 Su Geçirmez Taşınabilir Bluetooth Hoparlör Mavi", UnitsInStock = 50, Price = 259.90M },
                new Product { Id = 5, ImageLocation = "/Images/Products/28dc3885-dd3e-4ba9-be0d-79f792d7669b.jpg", Name = "Braun Silk Expert Pro 5 PL5124 Yeni Nesil IPL Cihazı 400.000 Atım", UnitsInStock = 50, Price = 3399.90M },
                new Product { Id = 6, ImageLocation = "/Images/Products/1f1e8719-bd4a-45ef-b52a-4d4b2f1372e3.jpg", Name = "Ofçay Efsane Filiz Siyah Cay 1 Kg", UnitsInStock = 50, Price = 20M }
            );
        }
    }
}
