using System.Collections.Generic;
using ECommerceApp.Core.DataAccess;
using ECommerceApp.Entities.Concrete;
using ECommerceApp.Entities.Dtos;

namespace ECommerceApp.DataAccess.Abstract
{
    public interface ICartDal:IEntityRepository<Cart>
    {
        List<CartDto> GetCartProducts();
    }
}
