using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unico.Data.Entities;
using Unico.Data.Interfaces;

namespace Unico.Controllers
{
    public class HomeController : Controller
    {
        public IRepository<Product> ProductRepository { get; set; }

        public HomeController()
        {
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Измените этот шаблон, чтобы быстро приступить к работе над приложением ASP.NET MVC.";

            var p = new Product() { ExternalId = Guid.NewGuid(), Name = "Test 1" };
            ProductRepository.Add(p);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Страница описания приложения.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Страница контактов.";

            return View();
        }
    }
}
