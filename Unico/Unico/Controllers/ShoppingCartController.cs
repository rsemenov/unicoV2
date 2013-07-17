using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unico.Data.Entities;
using Unico.Data.Interfaces;
using Unico.Models;

namespace Unico.Controllers
{
    [Authorize]
    public class ShoppingCartController : Controller
    {
        public IRepository<CartItem> CartItemsRepository { get; set; }
        public IRepository<Product> ProductsRepository { get; set; }
        //
        // GET: /ShoppingCart/
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserData userData)
        {
            
            return View();
        }

    }
}
