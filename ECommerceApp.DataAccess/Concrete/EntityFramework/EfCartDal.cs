using System.Collections.Generic;
using System.Linq;
using ECommerceApp.Core.DataAccess.EntityFramework;
using ECommerceApp.DataAccess.Abstract;
using ECommerceApp.DataAccess.Concrete.EntityFramework.Contexts;
using ECommerceApp.Entities.Concrete;
using ECommerceApp.Entities.Dtos;

namespace ECommerceApp.DataAccess.Concrete.EntityFramework
{
    public class EfCartDal : EfEntityRepositoryBase<Cart, ECommerceAppContext>, ICartDal
    {
        public List<CartDto> GetCartProducts()
        {
            using (ECommerceAppContext context = new ECommerceAppContext())
            {
                return (from product in context.Products
                        join basketProduct in context.BasketProducts on product.Id equals basketProduct.Product.Id
                        select new CartDto
                        {
                            ProductId = product.Id,
                            Quantity = basketProduct.Quantity,
                            Name = product.Name,
                            QuantityEqualsStock = product.UnitsInStock == basketProduct.Quantity,
                            ProductTotalPrice = product.Price * basketProduct.Quantity
                        }).ToList();
            }
        }
    }
}
