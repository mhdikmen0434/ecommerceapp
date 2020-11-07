using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceApp.Core.Results;
using ECommerceApp.Entities.Concrete;
using ECommerceApp.Entities.Dtos;

namespace ECommerceApp.Business.Abstract
{
    public interface ICartService
    {
        IDataResult<CartDtoForPage> GetList();
        IResult AddByProductId(int productId);
        IResult UpdateBasketProductByModel(CartDtoForUpdate model);
        IResult DeleteByProductId(int productId);

    }
}
