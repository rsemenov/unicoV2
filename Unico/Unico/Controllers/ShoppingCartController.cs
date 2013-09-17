using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unico.Data.Entities;
using Unico.Data.Interfaces;
using Unico.Models;
using Unico.Infrastructure;

namespace Unico.Controllers
{
    [Authorize]
    public class ShoppingCartController : Controller
    {
        public IRepository<Data.Entities.CartItem> CartItemsRepository { get; set; }
        public IRepository<Product> ProductsRepository { get; set; }

        //
        // GET: /ShoppingCart/
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserData userData)
        {
            var shoppingCartId = Session.GetShoppingCardId();
            var items = CartItemsRepository.FindAll(cart => cart.OrderId == shoppingCartId);

            var model = new ShoppingCartModel()
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

            return View(model);
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

        //[HttpPost]
        //[Authorize]
        [AllowAnonymous]
        public PartialViewResult AddProduct(Guid productId, int count, UserData userData)
        {
            var shoppingCartId = Session.GetShoppingCardId();
            var cartItem = new Unico.Data.Entities.CartItem() { OrderId = shoppingCartId, Count = count, ProductId = productId };
            CartItemsRepository.SaveOrUpdateAll(new[] { cartItem });
            return ShoppingCartWidget(userData);
        }

    }
}
