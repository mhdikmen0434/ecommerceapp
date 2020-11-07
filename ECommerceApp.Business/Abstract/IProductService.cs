using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceApp.Entities.Concrete;

namespace ECommerceApp.Business.Abstract
{
    public interface IProductService
    {
        List<Product> Getlist();
        Product GetById(int id);
    }
}
