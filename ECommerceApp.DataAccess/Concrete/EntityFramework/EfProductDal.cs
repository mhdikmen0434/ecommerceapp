using System.Collections.Generic;
using System.Linq;
using ECommerceApp.Core.DataAccess.EntityFramework;
using ECommerceApp.DataAccess.Abstract;
using ECommerceApp.DataAccess.Concrete.EntityFramework.Contexts;
using ECommerceApp.Entities.Concrete;

namespace ECommerceApp.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, ECommerceAppContext>, IProductDal
    {
    }
}
