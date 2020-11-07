using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ECommerceApp.Entities.Concrete;

namespace ECommerceApp.DataAccess.Concrete.EntityFramework.Configurations
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            ToTable("Products");

            HasKey(x => x.Id);
            HasIndex(x => x.Id);
            Property(x => x.Id).HasColumnName("Id");
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Name).HasColumnName("Name");
            Property(x => x.ImageLocation).HasColumnName("ImageLocation");
            Property(x => x.UnitsInStock).HasColumnName("UnitsInStock");
            Property(x => x.Price).HasColumnName("Price");

        }
    }
}
