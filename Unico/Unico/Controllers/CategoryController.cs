using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unico.Data.Entities;
using Unico.Data.Interfaces;
using Unico.Infrastructure;

namespace Unico.Controllers
{
    public class CategoryController : Controller
    {
        public IRepository<Category> CategoryRepository { get; set; }
        public IRepository<CartItem> CartItemsRepository { get; set; }

        public ActionResult Show(int categoryId)
        {
            var cat = CategoryRepository.Find(c => c.CategoryId == categoryId);
            if (cat != null)
            {
                return View(cat);
            }

            return RedirectToAction("PageNotFound", "Home");
        }

    }
}
