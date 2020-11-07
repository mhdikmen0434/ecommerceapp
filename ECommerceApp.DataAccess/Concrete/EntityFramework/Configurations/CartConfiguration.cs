using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ECommerceApp.Entities.Concrete;

namespace ECommerceApp.DataAccess.Concrete.EntityFramework.Configurations
{
    public class CartConfiguration : EntityTypeConfiguration<Cart>
    {
        public CartConfiguration()
        {
            ToTable("Cart");

            HasKey(x => x.Id);
            HasIndex(x => x.Id);
            Property(x => x.Id).HasColumnName("Id");
            //Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //Property(x => x.ProductId).HasColumnName("ProductId");
            Property(x => x.Quantity).HasColumnName("Quantity");

            HasRequired(x => x.Product).WithOptional(x => x.Cart);

        }
    }
}
