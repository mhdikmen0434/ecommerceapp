using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECommerceApp.Business.Abstract;
using ECommerceApp.Business.Concrete;
using ECommerceApp.DataAccess.Concrete.EntityFramework;
using ECommerceApp.Entities.Dtos;

namespace ECommerceApp.Web.UI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICartService _cartService;

        public ProductsController()
        {
            _productService = new ProductManager(new EfProductDal());
            _cartService = new CartManager(new EfCartDal(), _productService);
        }

        // GET: Products
        public ActionResult Index()
        {
            return View(_productService.Getlist());
        }
        [HttpGet]
        public ActionResult GetCart()
        {
            var basketResult = _cartService.GetList();
            return Json(basketResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddtoCart(int id)
        {
            return Json(_cartService.AddByProductId(id));
        }

        [HttpPost]
        public ActionResult UpdateCart(CartDtoForUpdate model)
        {
            return Json(_cartService.UpdateBasketProductByModel(model));
        }

        [HttpPost]
        public ActionResult DeleteFromCart(int id)
        {
            return Json(_cartService.DeleteByProductId(id));
        }
    }
}