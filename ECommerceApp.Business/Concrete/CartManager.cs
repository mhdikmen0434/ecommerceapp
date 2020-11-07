using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceApp.Business.Abstract;
using ECommerceApp.Business.Constants;
using ECommerceApp.Core.Results;
using ECommerceApp.DataAccess.Abstract;
using ECommerceApp.Entities.Concrete;
using ECommerceApp.Entities.Dtos;

namespace ECommerceApp.Business.Concrete
{
    public class CartManager : ICartService
    {
        private readonly ICartDal _cartDal;
        private readonly IProductService _productService;
        public CartManager(ICartDal cartDal, IProductService productService)
        {
            _cartDal = cartDal;
            _productService = productService;
        }

        public IDataResult<CartDtoForPage> GetList()
        {
            var result = _cartDal.GetCartProducts();
            if (result.Count == 0)
                return new ErrorDataResult<CartDtoForPage>(Messages.CartProductNotExists);
            return new SuccessDataResult<CartDtoForPage>(new CartDtoForPage { Cart = result, TotalPrice = result.Select(x => x.ProductTotalPrice).Sum(x => x) });
        }

        public IResult AddByProductId(int productId)
        {
            var product = _productService.GetById(productId);
            if (product == null)
                return new ErrorResult(Messages.ProductNotFound);
            var basketProduct = _cartDal.Get(x => x.Product.Id == productId);
            if (basketProduct == null)
            {
                _cartDal.Add(new Cart
                {
                    Id = productId,
                    Quantity = 1
                });
            }
            else
            {
                if (!((basketProduct.Quantity + 1) > product.UnitsInStock))
                {
                    basketProduct.Quantity += 1;
                    _cartDal.Update(basketProduct);
                }
                else
                {
                    return new ErrorResult(Messages.CartProductNotAddedMore);
                }

            }
            return new SuccessResult(Messages.CartProductAdded);
        }

        public IResult UpdateBasketProductByModel(CartDtoForUpdate model)
        {
            var product = _productService.GetById(model.ProductId);
            if (product == null)
                return new ErrorResult(Messages.ProductNotFound);
            var basketProduct = _cartDal.Get(x => x.Product.Id == model.ProductId);
            if (model.Quantity == 0)
            {
                _cartDal.Delete(basketProduct);
                return new SuccessResult(Messages.CartProductDeleted);
            }
            else if (model.Quantity < 0)
            {
                return new ErrorResult(Messages.CartProductQuantityCannotBeNegative);
            }
            else if (product.UnitsInStock - model.Quantity < 0)
            {
                return new ErrorResult(string.Concat(Messages.CartProductNotAddedMore, " Stok Adedi :", product.UnitsInStock));
            }

            basketProduct.Quantity = model.Quantity;
            _cartDal.Update(basketProduct);
            return new SuccessResult(Messages.CartProductUpdated);
        }

        public IResult DeleteByProductId(int productId)
        {
            var product = _productService.GetById(productId);
            if (product == null)
                return new ErrorResult(Messages.ProductNotFound);
            var card = _cartDal.Get(x => x.Product.Id == productId);
            if (card != null)
            {
                _cartDal.Delete(card);
            }
            return new SuccessResult(Messages.CartProductDeleted);
        }
    }
}
