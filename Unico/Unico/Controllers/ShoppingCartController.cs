﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unico.Data.Entities;
using Unico.Data.Interfaces;
using Unico.Models;
using Unico.Infrastructure;
using Unico.Helpers;

namespace Unico.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IRepository<Data.Entities.CartItem> CartItemsRepository { get; set; }
        public IRepository<Product> ProductsRepository { get; set; }

        //
        // GET: /ShoppingCart/
        //[ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Index(UserData userData)
        {
             return View(GetShoppingCartModel(userData));
        }

        [AllowAnonymous]
        public PartialViewResult ShoppingCartWidget(UserData userData)
        {
            var model = new ShoppingCartWidgetModel();
            if (null != userData)
            {
                var shoppingCartId = Session.GetShoppingCardId();
                var itemsCount = CartItemsRepository.FindAll(cart => cart.OrderId == shoppingCartId).Count();
                model.Count = itemsCount;
            }

            return PartialView("ShoppingCartWidget", model);
        }

        [HttpPost]
        [AjaxAuthorize]
        public PartialViewResult AddProduct(Guid productId, int count, UserData userData)
        {
            var shoppingCartId = Session.GetShoppingCardId();
            var cartItem = CartItemsRepository.Find(c => c.OrderId == shoppingCartId && c.ProductId == productId);
            if (cartItem == null)
            {
                cartItem = new Unico.Data.Entities.CartItem() { OrderId = shoppingCartId, ProductId = productId };
            }
            cartItem.Count += count;
            CartItemsRepository.SaveOrUpdateAll(cartItem);
            return ShoppingCartWidget(userData);
        }

        [AjaxAuthorize]
        public PartialViewResult SetCount(Guid productId, int count, UserData userData)
        {
            if (count == 0)
            {
                return DeleteItem(productId, userData);
            }
            var shoppingCartId = Session.GetShoppingCardId();
            var cartItem = CartItemsRepository.Find(c => c.OrderId == shoppingCartId && c.ProductId == productId);
            if (cartItem != null)
            {
                cartItem.Count = count;
                CartItemsRepository.SaveOrUpdateAll(cartItem);
            }
            return PartialView("ShoppingCartTable", GetShoppingCartModel(userData));
        }

        [AjaxAuthorize]
        public PartialViewResult DeleteItem(Guid productId, UserData userData)
        {
            var shoppingCartId = Session.GetShoppingCardId();
            var cartItem = CartItemsRepository.Find(c => c.OrderId == shoppingCartId && c.ProductId == productId);
            if (cartItem != null)
            {                
                CartItemsRepository.Delete(cartItem);
            }
            return PartialView("ShoppingCartTable", GetShoppingCartModel(userData));
        }

        private ShoppingCartModel GetShoppingCartModel(UserData userData)
        {

            var shoppingCartId = Session.GetShoppingCardId();
            var items = CartItemsRepository.FindAll(cart => cart.OrderId == shoppingCartId);

            return new ShoppingCartModel()
            {
                CartItems = items.Select(item =>
                {
                    var product = ProductsRepository.Find(p => p.ExternalId == item.ProductId);
                    return new Unico.Models.CartItem()
                    {
                        ProductId = product.ExternalId,
                        Brand = product.Brand.Name,
                        Count = item.Count,
                        Description = product.Description,
                        Name = product.Name,
                        Price = product.Price
                    };
                }).ToList()
            };
        }


    }
}
