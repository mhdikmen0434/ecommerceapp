using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceApp.Business.Abstract;
using ECommerceApp.DataAccess.Abstract;
using ECommerceApp.Entities.Concrete;

namespace ECommerceApp.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> Getlist()
        {
           return _productDal.GetList();
        }

        public Product GetById(int id)
        {
            return _productDal.Get(x => x.Id == id);
        }
    }
}
