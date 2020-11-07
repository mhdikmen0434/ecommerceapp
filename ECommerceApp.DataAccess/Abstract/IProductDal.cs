using System.Collections.Generic;
using ECommerceApp.Core.DataAccess;
using ECommerceApp.Entities.Concrete;

namespace ECommerceApp.DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
    }
}
